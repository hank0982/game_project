using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //declare variable for default values...
    public int defaultStrenght = 100;
    public float defaultHealth = 100.0f;
    public int KnockingDistancePerLevel = 500;
    public Transform PlayerTransform;
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
            float damage = 1.0f;
            if (hit.gameObject.name == "Shuriken01")
            {
                int ShurikenLevel = PlayerPrefs.GetInt("ShurikenLevel");
                damage = damage * 5 + ShurikenLevel * 3;
            }
            else if (hit.gameObject.name == "Sword")
            {
                int SwordLevel = PlayerPrefs.GetInt("SwordLevel");
                damage = damage * 5 + SwordLevel * 6;
            }
            else if (hit.gameObject.name == "Spear")
            {
                int SpearLevel = PlayerPrefs.GetInt("SpearLevel");
                damage = damage * 4 + SpearLevel * 10;
            }
            else
            {   
                int HammerLevel = PlayerPrefs.GetInt("HammerLevel");
                damage = damage * 5 + HammerLevel * 5;
                if (HammerLevel >= 2)
                {
                    int possiblityToHitFarAway = Random.Range(0, 100);
                    if (possiblityToHitFarAway < (HammerLevel - 1) * 10)
                    {
                        GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().mass * PlayerTransform.forward * KnockingDistancePerLevel);
                    }
                }
            }
            MonHealth -= damage;

            //If it influences it's strength, then factor it in like...
            MonStrength -= 1; //so the strength will go down but slower then the health.
     }

        if (MonHealth < 0) //if the monster as no more health, destroy him...
            Destroy(gameObject);
  }
}
