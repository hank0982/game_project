using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShurikenScript : MonoBehaviour
{
    private float lifetime = 5.0f;
    private GameObject obj;
    private GameObject partical;
    void Start()
    {
        Destroy(gameObject, lifetime);
        int shurikenLevel = PlayerPrefs.GetInt("ShurikenLevel");
        if (shurikenLevel > 1)
        {
            
            partical = (GameObject)Resources.Load("WeaponEffect/CFX_ElectricityBall", typeof(GameObject));
            obj = (GameObject)Instantiate(partical, transform.position, transform.rotation);
            obj.transform.parent = transform;
        }
    }
    private void OnCollisionEnter(Collision hit)  //see web below for explanation
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

       
    }
}
