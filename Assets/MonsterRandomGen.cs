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
            
    }

    // Update is called once per frame
    void Update()
    {
        if(respawns == null)
        {
            int level = PlayerPrefs.GetInt("level");
            int difficulty = 50 - level * 8;
            respawns = GameObject.FindGameObjectsWithTag("Floor");
            if (respawns.Length == 0)
                Debug.Log("No game objects are tagged with 'Floor'");
            foreach (GameObject respawn in respawns)
            {
                int num = Random.Range(0, respawnPrefab.Length + 1);
                //Instantiate(respawnPrefab[num], respawn.transform.position, Quaternion.identity);
                if (respawn.transform.position.x <= new Vector3(10, 0, 10).x)
                    continue;
                if (respawn.transform.position.z <= new Vector3(10, 0, 10).z)
                    continue;
                Debug.Log("pos:" + respawn.transform.position);
                if (Random.Range(0, 100) > difficulty)
                    Instantiate(respawnPrefab[num], respawn.transform.position, Quaternion.identity);
            }
        }
    }
}
