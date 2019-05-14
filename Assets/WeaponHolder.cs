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
