using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAni : MonoBehaviour
{
    Animation anim;
    public float speed;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.isPlaying)
        {
            return;
        }
        else
        {
            anim.Play("Idle");
        }

        //PlayerMovement();
    }

    private void PlayerMovement()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * speed;
    }

}
