using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //declare variable for default values...
    public int defaultStrenght = 100;
    public float defaultHealth = 100.0f;

    //variables that will be used during combat
    public int monStrength;
    public int MonStrength
    {
        get { return monStrength; }
        set { monStrength = value; }
    }

    public float monHealth;
    public float MonHealth   ///why a float here and not for strength as well?
    {
        get { return monHealth; }
        set { monHealth = value; }
    }

    private void Start()
    {
        int level = PlayerPrefs.GetInt("level");

        monStrength = defaultStrenght;
        monHealth = defaultHealth;
    }

    private void OnCollisionEnter(Collision hit)  //see web below for explanation
    {
        //Debug.Log(hit.gameObject);

        if (hit.gameObject.tag == "Weapon") //you want to make that it's the player that is hitting the monster
        {
            if (hit.gameObject.name == "Shuriken01")
            {

            } else if (hit.gameObject.name == "Sword")
            {

            } else if (hit.gameObject.name == "Spear")
            {

            }
            MonHealth -= 10.0f;

            //If it influences it's strength, then factor it in like...
            MonStrength -= 1; //so the strength will go down but slower then the health.
     }

        if (MonHealth < 0) //if the monster as no more health, destroy him...
            Destroy(gameObject);
  }
}
