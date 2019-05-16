﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GetCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Coin at: "+transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("get the coin!");
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PlayerPrefs.Save();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
        
    }

}
