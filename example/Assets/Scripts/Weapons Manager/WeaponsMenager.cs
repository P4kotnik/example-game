using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsMenager : MonoBehaviour
{
    public GameObject currentWeaponInHands;
    public GameObject secondWeapon;
    public GameObject crosshair;
    public RecoilScript recoilScript;
    public PlayerMove playerMove;
    public PickUp pickUp;
    GameObject changeWeapon;

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
    public bool isShot;

    bool isSprint;

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
        CrosshairEnabled();
        isScoped();
        isSprint = playerMove.isSprint;

        if (currentWeaponInHands != null)
        {
            magazineCapacity = currentWeaponInHands.GetComponent<WeaponInfo>().magazineCapacity;
            currentMagazineCapacity = currentWeaponInHands.GetComponent<WeaponInfo>().currentMagazineCapacity;
            maxNumberOfMagazins = currentWeaponInHands.GetComponent<WeaponInfo>().maxNumberOfMagazins;
            currentNumberOfMagazins = currentWeaponInHands.GetComponent<WeaponInfo>().currentNumberOfMagazins;

            fireRate = currentWeaponInHands.GetComponent<WeaponInfo>().fireRate;

            if (Input.GetButton("Fire1") && readyToShot == true)
            {
                isShot = ShotInfo(true);
                readyToShot = false;
                fireTimer = fireRate;
            }
            else
            {
                isShot = ShotInfo(false);
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

        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha1)) && secondWeapon != null)
        {
            changeWeapon = currentWeaponInHands;
            secondWeapon.SetActive(true);
            currentWeaponInHands = secondWeapon;
            secondWeapon = changeWeapon;
            secondWeapon.SetActive(false);
            changeWeapon = null;
        }
    }

    public bool ShotInfo(bool shot)
    {
        if (currentNumberOfMagazins <= 0 && currentMagazineCapacity <= 0)
        {
            ammoOut = true;
        }
        else
        {
            ammoOut = false;
        }

        if (currentMagazineCapacity <= 0 && ammoOut == false && isReloading == false)
        {
            isReloading = true;
            currentWeaponInHands.GetComponent<WeaponInfo>().Reloading();
        }
        else if(currentMagazineCapacity > 0)
        {
            isReloading = false;
        }

        if (isReloading == true || ammoOut == true || isSprint == true)
        {
            return false;
        }
        else if (shot)
        {
            currentWeaponInHands.GetComponent<WeaponInfo>().currentMagazineCapacity--;
            recoilScript.Fire();
            return shot;
        }
        else
        {
            return false;
        }
    }

    void CrosshairEnabled()
    {
        if (playerMove.isSprint)
        {
            crosshair.SetActive(false);
        }
        else
        {
            crosshair.SetActive(true);
        }
    }

    public bool isScoped()
    {
        if (Input.GetButton("Fire2") && isReloading != true)
        {

            return true;
        }
        else
        {
            return false;
        }
    }
}
