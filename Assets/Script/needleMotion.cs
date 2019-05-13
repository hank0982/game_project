using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class needleMotion : MonoBehaviour
{
    public Transform[] target;
    public float speed;

    private int current = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            // GetComponent<Rigidbody>().MovePosition(pos);
            transform.position = pos;
        }
        else current = (current + 1) % target.Length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("hit by traps! : " + other.name + " " + other.tag);
            PlayerPrefs.SetInt("level", 1);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }

}
