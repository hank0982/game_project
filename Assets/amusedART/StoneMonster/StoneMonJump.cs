using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMonJump : MonoBehaviour
{
    public float speed;
    //Whether we are currently interpolating or not
    private bool _isLerping;
    public float timeTakenDuringLerp = 1.2f;

    //The start and finish positions for the interpolation
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    //The Time.time value when we started the interpolation
    private float _timeStartedLerping;
    public GameObject prefabBullet;
    public float shootForce;
    int state = 0;
    /// <summary>
    /// Called to begin the linear interpolation
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {

    }

    void StartLerping()
    {
        _isLerping = true;
        _timeStartedLerping = Time.time;

        //We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
        StartCoroutine("attackOrMove");

    }
    IEnumerator attackOrMove()
    {
        GameObject enemy;
        while (true)
        {
            if (state == 0)
            {
                yield return new WaitForSeconds(3.0f);

            }
            else
            {
                GameObject instanceBullet = Instantiate(prefabBullet,
                   transform.position + transform.forward * 1.5f,
                   transform.rotation);
                instanceBullet.AddComponent<FlyingMonsterFireBall>();

                instanceBullet.GetComponent<Rigidbody>
                ().AddForce(transform.forward * shootForce);
                yield return new WaitForSeconds(3.0f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Vector3 lookat = player.transform.position - gameObject.transform.position;

        if (state == 0)
        {
            if (dist < 20 && dist > 0)
            {
                transform.LookAt(player.transform, Vector3.up);
                if (Physics.Raycast(gameObject.transform.position, lookat, out RaycastHit hit, 20))
                {
                    Debug.Log(hit.collider.name);
                    if (hit.collider.name == "Player")
                    {
                        _startPosition = transform.position;
                        _endPosition = player.transform.position;
                        _endPosition.y = transform.position.y;
                        if (dist < 10)
                        {
                                state = 1;
                        }
                        
                        StartLerping();
                        //Debug.Log("I see u");
                    }
                }
              
            }
            else
            {
                gameObject.transform.Rotate(0f, 10f, 0f);
            }
        }
        else
        {
            if(dist > 5)
            {
                state = 0;
            }
            if (Physics.Raycast(gameObject.transform.position, lookat, out RaycastHit hit, 10))
            {
                if (hit.collider.name != "Player")
                {
                        state = 0;
                }
            }
            else
            {
                    state = 0;
            }
        }
       
    }
    void FixedUpdate()
    {
        if (_isLerping)
        {
            //We want percentage = 0.0 when Time.time = _timeStartedLerping
            //and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
            //In other words, we want to know what percentage of "timeTakenDuringLerp" the value
            //"Time.time - _timeStartedLerping" is.
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

            //Perform the actual lerping.  Notice that the first two parameters will always be the same
            //throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
            //to start another lerp)
            transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);

            //When we've completed the lerp, we set _isLerping to false
            if (percentageComplete >= 1.0f)
            {
                _isLerping = false;
            }
        }
    }


}
