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

    [Header("Shooting")]
    public int magazineCapacity;
    public int currentMagazineCapacity;
    public int maxNumberOfMagazins;
    public int currentNumberOfMagazins;
    public float fireRate;

    float fireTimer;
    public bool isReloading;
    public bool readyToShot;
    public bool ammoOut;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponInHands = pickUp.currentWeapon;
        readyToShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetImageWeaponsOnUI();
        ChangeWeapon();

        if (currentWeaponInHands != null)
        {
            magazineCapacity = currentWeaponInHands.GetComponent<WeaponInfo>().magazineCapacity;
            currentMagazineCapacity = currentWeaponInHands.GetComponent<WeaponInfo>().currentMagazineCapacity;
            maxNumberOfMagazins = currentWeaponInHands.GetComponent<WeaponInfo>().maxNumberOfMagazins;
            currentNumberOfMagazins = currentWeaponInHands.GetComponent<WeaponInfo>().currentNumberOfMagazins;
            ammoOut = currentWeaponInHands.GetComponent<WeaponInfo>().ammoOut;

            fireRate = currentWeaponInHands.GetComponent<WeaponInfo>().fireRate;

            if (Input.GetMouseButton(0) && readyToShot == true)
            {
                Shot();
                readyToShot = false;
                fireTimer = fireRate;
            }

            if (fireTimer >= 0)
            {
                fireTimer -= Time.deltaTime;
            }
            else
            {
                readyToShot = true;
            }
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

    void ChangeWeapon()
    {
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

    public bool Shot()
    {
        if (currentMagazineCapacity <= 0 && ammoOut != true)
        {
            isReloading = true;
            currentWeaponInHands.GetComponent<WeaponInfo>().Reloading();
        }
        else
        {
            isReloading = false;
        }

        if (isReloading == true && ammoOut == true)
        {
            return false;
        }
        else
        {
            currentWeaponInHands.GetComponent<WeaponInfo>().currentMagazineCapacity--;
            return true;
        }
    }
}