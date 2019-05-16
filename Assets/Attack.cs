using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public int MushroomAD;
    public int StoneAD;
    public int MummyAD;
    public int PlayerHP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP < 0)
        {
            Debug.Log("hit by monsters!");
            PlayerPrefs.SetInt("level", 1);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }

    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "MonsterBottom")
        {
            Debug.Log("Player hit.");
            int level = PlayerPrefs.GetInt("level");

            if (hit.gameObject.name == "StoneBottom")
            {
                Debug.Log("Player hit by stone.");
                PlayerHP -= StoneAD * level;
            }

            if (hit.gameObject.name == "MushroomBottom")
            {
                Debug.Log("Player hit by mushroom.");
                PlayerHP -= MushroomAD * level;
            }

            if (hit.gameObject.name == "MummyBottom")
            {
                Debug.Log("Player hit by mummy.");
                PlayerHP -= MummyAD * level;
            }

            else
            {
                Debug.Log("Player hit by something else.");
            }
        }
    }
}
