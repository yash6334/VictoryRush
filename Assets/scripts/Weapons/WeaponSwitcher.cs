using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    int curentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();

    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach ( Transform weapon in transform )
        {
            if(weaponIndex == curentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            curentWeapon = 0;
            SetWeaponActive();
        }
        if (Input.GetKeyDown("2"))
        {
            curentWeapon = 1;
            SetWeaponActive();
        }
        if (Input.GetKeyDown("3"))
        {
            curentWeapon = 2;
            SetWeaponActive();
        }
        
        if(Input.mouseScrollDelta.y > 0 || Input.mouseScrollDelta.y < 0)
        {
            curentWeapon = curentWeapon + (int)Input.mouseScrollDelta.y;
            curentWeapon = mod(curentWeapon, 3);
            SetWeaponActive();
        }
    }

    int mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}
