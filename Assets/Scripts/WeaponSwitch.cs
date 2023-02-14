using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(weapons.Length);
        int previousWeapon = selectedWeapon;
        print(previousWeapon);
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            selectedWeapon = NextWeapon();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            selectedWeapon = PreviousWeapon();
        }
        if (previousWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
        WeaponNumeric();
    }

    private void WeaponNumeric()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        

    }

    private int PreviousWeapon()
    {
        if (selectedWeapon <= 0)
        {
            return weapons.Length -1;
        }
        else
        {
            return --selectedWeapon;
        }
    }
    private int NextWeapon()
    {
        if (selectedWeapon >= weapons.Length -1)
        {
            return 0;
        }
        else
        {
            return ++selectedWeapon;
        }
    }

    void SelectedWeapon()
    {
       // print("hi");
        int i = 0;
        foreach (Transform weapon in transform) 
        {
            if(weapon.CompareTag("weapon"))
            {
                if (i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);

                }
            }
        }
        i++;
    }

}
