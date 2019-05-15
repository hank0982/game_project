using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    public int selectedWeapon = 0;
    [SerializeField] private KeyCode attackKey;
    public float shurikenForwardForce;
    public Transform playerTransform;
    private bool isAttacking;
    public Image[] weapons;
    private GameObject generatedPartial;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        SelectWeapon();
        PlayerPrefs.SetInt("SwordLevel", 1);
        PlayerPrefs.SetInt("SpearLevel", 1);
        PlayerPrefs.SetInt("HammerLevel", 1);
        PlayerPrefs.SetInt("ShurikenLevel", 1);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            selectedWeapon++;
            selectedWeapon %= transform.childCount;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon == 0)
                selectedWeapon = transform.childCount;
            selectedWeapon--;
        }
        if (previousSelectedWeapon != Math.Abs(selectedWeapon))
        {
            SelectWeapon();
            if (selectedWeapon != 2 && generatedPartial != null)
            {
                GameObject.DestroyImmediate(generatedPartial, true);
                generatedPartial = null;
            }
        }
        AttackInput();
    }
    private void AttackInput()
    {

        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            StartCoroutine("AttackRoutine");
            isAttacking = true;
        }

    }
    IEnumerator AttackRoutine()
    {

        yield return new WaitForSeconds(0.5f);
        
        if (selectedWeapon == 3)
        {
            GameObject shootingWeapon = transform.GetChild(3).gameObject;
            GameObject bullet = Instantiate(shootingWeapon, playerTransform.position + playerTransform.up * 0.5f + playerTransform.forward, Quaternion.identity);
            bullet.AddComponent<Rigidbody>();
            bullet.AddComponent<FlyingShurikenScript>();
            bullet.GetComponent<Rigidbody>().mass = 1;
            bullet.GetComponent<Rigidbody>().AddForce(playerTransform.forward * shurikenForwardForce);
        }
        if (selectedWeapon == 0)
        {
            int SpearLevel = PlayerPrefs.GetInt("SpearLevel");
            if (SpearLevel == 2)
            {
                GameObject partical = (GameObject)Resources.Load("WeaponEffect/CFX4HitPaintC", typeof(GameObject));
                GameObject Weapon = transform.GetChild(0).gameObject;
                GameObject bullet = Instantiate(partical, Weapon.transform.position, Quaternion.identity);
            } else if (SpearLevel > 2)
            {
                GameObject partical = (GameObject)Resources.Load("WeaponEffect/CFX2_Big_Splash", typeof(GameObject));
                GameObject Weapon = transform.GetChild(0).gameObject;
                GameObject bullet = Instantiate(partical, playerTransform.position + playerTransform.forward, Quaternion.LookRotation(-playerTransform.forward));
            }
        }
        if (selectedWeapon == 1)
        {
            int HammerLevel = PlayerPrefs.GetInt("HammerLevel");
            if (HammerLevel == 2)
            {
                GameObject partical = (GameObject)Resources.Load("WeaponEffect/CFX3_Hit_Light_C_Air", typeof(GameObject));
                GameObject Weapon = transform.GetChild(1).gameObject;
                GameObject bullet = Instantiate(partical, Weapon.transform.position, Quaternion.identity);
            }
            else if (HammerLevel > 2) 
            {
                GameObject partical = (GameObject)Resources.Load("WeaponEffect/CFX2_RockHit", typeof(GameObject));
                GameObject Weapon = transform.GetChild(1).gameObject;
                GameObject bullet = Instantiate(partical, playerTransform.position + playerTransform.forward, Quaternion.LookRotation(-playerTransform.forward));
            }
        }
        if (selectedWeapon == 2)
        {
            int SwordLevel = PlayerPrefs.GetInt("SwordLevel");
            if (SwordLevel == 0)
            {

                if (generatedPartial == null)
                {
                    generatedPartial = (GameObject)Resources.Load("WeaponEffect/CFX4Fire", typeof(GameObject));
                    generatedPartial.name = "SwordLevelTwoFire";
                    GameObject Weapon = transform.GetChild(2).gameObject;
                    GameObject bullet = Instantiate(generatedPartial, Weapon.transform.position, Quaternion.identity);
                    bullet.transform.parent = playerTransform;
                }
            }
            else if (SwordLevel ==1)
            {
                if (generatedPartial != null && generatedPartial.name == "SwordLevelTwoFire")
                {
                    GameObject.DestroyImmediate(generatedPartial, true);
                    generatedPartial = null;
                }
                if (generatedPartial == null)
                {
                    generatedPartial = (GameObject)Resources.Load("WeaponEffect/CFX3_Fire_Shield", typeof(GameObject));
                    GameObject Weapon = transform.GetChild(2).gameObject;
                    GameObject bullet = Instantiate(generatedPartial, playerTransform.position + playerTransform.forward, Quaternion.LookRotation(-playerTransform.forward));
                    bullet.transform.parent = playerTransform;
                }
               
            }
        }
        isAttacking = false;
    }
   
    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == Math.Abs(selectedWeapon));
            i++;
        }
        i = 0;
        foreach (Image weapon in weapons)
        {
            weapon.GetComponent<Image>();
            if (i == Math.Abs(selectedWeapon))
            {
                weapon.color = Color.yellow;
            }
            else
            {
                weapon.color = Color.white;
            }
            i++;
        }                                                                                                                           
    }

}
