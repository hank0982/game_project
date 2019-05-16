using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Transform target;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Coin").transform;
        targetPosition = target.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
}
