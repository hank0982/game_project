using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyJump : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (dist < 20 && dist > 0)
        {
            Vector3 lookat = player.transform.position - gameObject.transform.position;


            if (Physics.Raycast(gameObject.transform.position, lookat, out RaycastHit hit, 20))
            {
                if (hit.collider.name == "Player")
                {
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, 0.1f);
                    lookat.y = 0;
                    gameObject.transform.forward = lookat;
                    //Debug.Log("I see u");
                }

            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * speed;
    }
}
