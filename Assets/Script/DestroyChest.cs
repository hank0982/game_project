using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(1, 100);
        Debug.Log(random);
        if(random % 7 != 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
