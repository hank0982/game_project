using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandomGen : MonoBehaviour
{
    public GameObject[] respawnPrefab;
    private GameObject[] respawns;
    // Start is called before the first frame update
    void Start()
    {
        //respawns = GameObject.FindGameObjectsWithTag("Floor");
        //if (respawns.Length == 0)
        //    Debug.Log("No game objects are tagged with 'Floor'");
        //else
        //{
        //    foreach (GameObject respawn in respawns)
        //    {
        //        //if(Random.Range(0,5) > 3)
        //        //{
        //        //    GameObject monster = respawnPrefab[Random.Range(0, 3)];
        //        //    Instantiate(monster, respawn.transform.position, respawn.transform.rotation);
        //        //}
        //        //GameObject monster = respawnPrefab[1];
        //        //Instantiate(monster, respawn.transform.position, respawn.transform.rotation);
        //        Debug.Log("respwans:" + respawn.transform.position);
        //        Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(respawns == null)
        {
            respawns = GameObject.FindGameObjectsWithTag("Floor");
            if (respawns.Length == 0)
                Debug.Log("No game objects are tagged with 'Floor'");
            foreach (GameObject respawn in respawns)
            {
                //if(Random.Range(0,5) > 3)
                //{
                //    GameObject monster = respawnPrefab[Random.Range(0, 3)];
                //    Instantiate(monster, respawn.transform.position, respawn.transform.rotation);
                //}
                //GameObject monster = respawnPrefab[1];
                //Instantiate(monster, respawn.transform.position, respawn.transform.rotation);
                Debug.Log("respwans:" + respawn.transform.position);
                //if(Random.Range(0,10) > 6)
                //{
                //    Instantiate(respawnPrefab[0], respawn.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                //    continue;
                //}
                //if (Random.Range(0, 10) > 7)
                //{
                //    Instantiate(respawnPrefab[1], respawn.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                //    continue;
                //}
                //if (Random.Range(0, 10) > 8)
                //{
                //    Instantiate(respawnPrefab[2], respawn.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                //    continue;
                //}
                int num = Random.Range(0, respawnPrefab.Length + 1);
                if (Random.Range(0, 10) > 8)
                    Instantiate(respawnPrefab[num], respawn.transform.position + new Vector3(0, 1, 0), Quaternion.identity);


            }
        }
    }
}
