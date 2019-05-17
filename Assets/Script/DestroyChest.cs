using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChest : MonoBehaviour
{

    public GameObject[] weapons;


    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(1, 101);
        // Debug.Log(random);
        int level = PlayerPrefs.GetInt("level");
        if(random > 10 + (5-level) * 5) 
        {
            //Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player get the box!");
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.enabled = false;
            int randomNum = Random.Range(0, 4);
            
            StartCoroutine(TemporarilyActivate(randomNum));

            if (randomNum == 0)
            {
                if(PlayerPrefs.GetInt("SpearLevel") < 3)
                {
                    PlayerPrefs.SetInt("SpearLevel", (PlayerPrefs.GetInt("SpearLevel") + 1));
                }
            }
            else if (randomNum == 1)
            {
                if (PlayerPrefs.GetInt("HammerLevel") < 3)
                {
                    PlayerPrefs.SetInt("HammerLevel", (PlayerPrefs.GetInt("HammerLevel") + 1));
                }
            }
            else if (randomNum == 2)
            {
                if (PlayerPrefs.GetInt("SwordLevel") < 3)
                {
                    PlayerPrefs.SetInt("SwordLevel", (PlayerPrefs.GetInt("SwordLevel") + 1));
                }
            }
            else if (randomNum == 3)
            {
                if (PlayerPrefs.GetInt("ShurikenLevel") < 3)
                {
                    PlayerPrefs.SetInt("ShurikenLevel", (PlayerPrefs.GetInt("ShurikenLevel") + 1));
                }
            }
        }

    }

    private IEnumerator TemporarilyActivate(int weaponNum)
    {
        Debug.Log("Hero get: "+ weapons[weaponNum].gameObject);
        weapons[weaponNum].gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
