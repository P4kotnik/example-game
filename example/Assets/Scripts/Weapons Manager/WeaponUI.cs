using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image firstWeapon;
    public Image secondWeapon;

    public WeaponsMenager weaponsMenager;

    // Update is called once per frame
    void Update()
    {
        if (weaponsMenager.currentWeaponInHands != null)
        {
            firstWeapon.sprite = weaponsMenager.currentWeaponInHands.GetComponent<WeaponInfo>().weaponImage;
            if (weaponsMenager.secondWeapon != null)
            {
                secondWeapon.sprite = weaponsMenager.secondWeapon.GetComponent<WeaponInfo>().weaponImage;
            }
        }
    }
}
