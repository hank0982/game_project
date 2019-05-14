using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Image[] weapons;

    // Start is called before the first frame update
    void Start()
    {

        SelectWeapon();   
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
            selectedWeapon--;
            if(selectedWeapon < 0)
            {
                selectedWeapon = transform.childCount-1;
            }
        }
        if (previousSelectedWeapon != Math.Abs(selectedWeapon))
        {
            SelectWeapon();
        }
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
