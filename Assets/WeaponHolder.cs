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
    private int isParticalGenerated;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        SelectWeapon();
        PlayerPrefs.SetInt("SwordLevel", 1);
        PlayerPrefs.SetInt("SpearLevel", 1);
        PlayerPrefs.SetInt("HammerLevel", 1);
        PlayerPrefs.SetInt("ShurikenLevel", 1);
        isParticalGenerated = -1;
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
            Debug.Log(isParticalGenerated);
            if (selectedWeapon != 2 && isParticalGenerated != -1)
            {
                if(isParticalGenerated == 2)
                {
                    GameObject partical = GameObject.Find("SwordLevelTwoFire");
                    Destroy(partical, 0.5f);
                }
                else
                {
                    GameObject partical = GameObject.Find("SwordLevelThreeFire");
                    Destroy(partical, 0.5f);
                }
                isParticalGenerated = -1;
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
            int ShurikenLevel = PlayerPrefs.GetInt("ShurikenLevel");
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
            if (SwordLevel == 1)
            {

                if (isParticalGenerated == -1)
                {
                    GameObject generatedPartial = (GameObject)Resources.Load("WeaponEffect/CFX4Fire", typeof(GameObject));
                    GameObject Weapon = transform.GetChild(2).gameObject;
                    GameObject bullet = Instantiate(generatedPartial, Weapon.transform.position, Quaternion.identity);
                    bullet.transform.parent = playerTransform;
                    bullet.name = "SwordLevelTwoFire";
                    isParticalGenerated = 2;
                }
            }
            else if (SwordLevel >2)
            {
                if (isParticalGenerated == 2)
                {
                    GameObject partical = GameObject.Find("SwordLevelTwoFire");
                    GameObject.DestroyImmediate(partical, true);
                    isParticalGenerated = -1;
                }
                if (isParticalGenerated == -1)
                {
                    GameObject generatedPartial = (GameObject)Resources.Load("WeaponEffect/CFX3_Fire_Shield", typeof(GameObject));
                    GameObject Weapon = transform.GetChild(2).gameObject;
                    GameObject bullet = Instantiate(generatedPartial, playerTransform.position + playerTransform.forward, Quaternion.LookRotation(-playerTransform.forward));
                    bullet.transform.parent = playerTransform;
                    bullet.name = "SwordLevelThreeFire"; 
                    isParticalGenerated = 3;
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
