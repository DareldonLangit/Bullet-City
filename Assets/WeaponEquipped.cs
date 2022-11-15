using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipped : MonoBehaviour
{
    public WeaponSwitching playerSwitching;
    private int selectedWeapon;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectedWeapon = FindObjectOfType<WeaponSelect>().selectedWeapon;
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                FindObjectOfType<WeaponSwitching>().selectedWeapon = i;
                //if (selectedWeapon == 0)
                //{
                //    playerSwitching.selectedWeapon = 0;

                //} else if (selectedWeapon == 1)
                //{
                //    playerSwitching.selectedWeapon = 1;

                //}

                playerSwitching.selectedWeapon = i;
                //Debug.Log("Selected: " + i);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
