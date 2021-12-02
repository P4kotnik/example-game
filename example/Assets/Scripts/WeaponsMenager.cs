using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsMenager : MonoBehaviour
{
    public GameObject currentWeaponInHands;
    public GameObject secondWeapon;
    GameObject changeWeapon;
    public PickUp pickUp;

    [Header("Weapon UI")]
    public Image firstWeaponImage;
    public Image secondWeaponImage;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponInHands = pickUp.currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        SetImageWeaponsOnUI();

        if (secondWeapon != null)
        {
            secondWeapon.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && secondWeapon != null)
        {
            changeWeapon = currentWeaponInHands;
            secondWeapon.SetActive(true);
            currentWeaponInHands = secondWeapon;
            secondWeapon = changeWeapon;
            secondWeapon.SetActive(false);
            changeWeapon = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && secondWeapon != null)
        {
            changeWeapon = currentWeaponInHands;
            secondWeapon.SetActive(true);
            currentWeaponInHands = secondWeapon;
            secondWeapon = changeWeapon;
            secondWeapon.SetActive(false);
            changeWeapon = null;
        }
    }

    void SetImageWeaponsOnUI()
    {
        if (currentWeaponInHands != null)
        {
            currentWeaponInHands.SetActive(true);
            if (secondWeapon != null)
            {
                secondWeapon.SetActive(false);
            }
        }

        if (currentWeaponInHands == null)
        {
            firstWeaponImage.enabled = false;
            secondWeaponImage.enabled = false;
        }
        else if (currentWeaponInHands != null)
        {
            firstWeaponImage.enabled = true;
            if (secondWeapon != null)
            {
                secondWeaponImage.enabled = true;
            }
            else
            {
                secondWeaponImage.enabled = false;
            }
        }
    }
}
