using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    public int selectedWeapon;

    void Start()
    {
        //Select the first weapon
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        //Switches weapon based on the scroll wheel direction

        //Scrolling up
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            //if selectedWeapon is greater than or equal to the child count -1 
            if (selectedWeapon >= transform.childCount - 1)
            {
                //reset the weapon int to the first gun in the object
                selectedWeapon = 0;
            }
            else
            {
                //increment the weapon int
                selectedWeapon++;
            }
        }

        //Scrolling down
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            //if the selected weapon is lessthan or equal to 0
            if (selectedWeapon <= 0)
            {
                //reset the weapon int to the last guin in the object
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                //increment the weapon int
                selectedWeapon--;
            }
        }

        //if the previously selected weapon is not the currently selected weapon then
        if (previousSelectedWeapon != selectedWeapon)
        {
            //Select a new weapon
            SelectWeapon();
        }
    }


    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.GetComponent<Gun>().enabled = true;
                weapon.GetComponent<MeshRenderer>().enabled = true;
                weapon.Find("LaserSight").gameObject.SetActive(true);

            }
            else
            {
                weapon.GetComponent<Gun>().enabled = false;
                weapon.GetComponent<MeshRenderer>().enabled = false;
                weapon.Find("LaserSight").gameObject.SetActive(false);

            }
            i++;
        }
    }

}
