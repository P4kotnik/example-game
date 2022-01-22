using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsMenager : MonoBehaviour
{
    public GetInformation getInformation;
    [Space(10)]//weapon in equipment
    public GameObject currentWeaponInHands;
    public GameObject secondWeapon;

    [Space(10)]//pick up and change weapon
    public PickUp pickUp;
    GameObject changeWeapon;

    [Header("Weapon UI")]
    public Image firstWeaponImage;
    public Image secondWeaponImage;

    [Header("Shooting")]
    public float fireRate;
    float fireTimer;
    public bool readyToShot;
    public bool isReloading;
    public bool ammoOut;

    [Space(10)]
    public int magazineCapacity;
    public int currentMagazineCapacity;

    [Space(10)]
    public int maxNumberOfMagazines;
    public int currentNumberOfMagazines;

    [Space(10)]
    public GameObject crosshair;
    public RecoilScript recoilScript;

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
        getInformation.isScoped = IsScoped();

        if (currentWeaponInHands != null)
        {
            magazineCapacity = currentWeaponInHands.GetComponent<WeaponInfo>().magazineCapacity;
            currentMagazineCapacity = currentWeaponInHands.GetComponent<WeaponInfo>().currentMagazineCapacity;
            maxNumberOfMagazines = currentWeaponInHands.GetComponent<WeaponInfo>().maxNumberOfMagazines;
            currentNumberOfMagazines = currentWeaponInHands.GetComponent<WeaponInfo>().currentNumberOfMagazines;

            getInformation.scaleForCrosshair = currentWeaponInHands.GetComponent<WeaponInfo>().scaleForCrosshair;
            getInformation.smouthTimeForCrosshair = currentWeaponInHands.GetComponent<WeaponInfo>().waitTimeForCrosshair;

            fireRate = currentWeaponInHands.GetComponent<WeaponInfo>().fireRate;

            if (Input.GetButton("Fire1") && readyToShot == true)
            {
                getInformation.shot = ShotInfo(true);
                readyToShot = false;
                fireTimer = fireRate;
            }
            else
            {
                getInformation.shot = false;
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
            firstWeaponImage.enabled = true;
            if (secondWeapon != null)
            {
                secondWeapon.SetActive(false);
                secondWeaponImage.enabled = true;
            }
            else
            {
                secondWeaponImage.enabled = false;
            }
        }
        else
        {
            firstWeaponImage.enabled = false;
            secondWeaponImage.enabled = false;
        }
    }

    void ChangeWeapon()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha1)) && secondWeapon != null)
        {
            isReloading = false;
            currentWeaponInHands.GetComponent<WeaponInfo>().weaponAnimation.Play("Idle");

            changeWeapon = currentWeaponInHands;
            currentWeaponInHands = secondWeapon;
            secondWeapon = changeWeapon;
            changeWeapon = null;
        }
    }

    public bool ShotInfo(bool shot)
    {
        if (currentNumberOfMagazines <= 0 && currentMagazineCapacity <= 0)
            ammoOut = true;
        else
            ammoOut = false;

        if (currentMagazineCapacity <= 0 && ammoOut == false && isReloading == false)
        {
            isReloading = true;
            currentWeaponInHands.GetComponent<WeaponInfo>().Reloading();
        }
        else if(currentMagazineCapacity > 0)
        {
            isReloading = false;
        }

        if (currentMagazineCapacity <= 0 || ammoOut == true || getInformation.isSprint)
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

    bool IsScoped()
    {
        if (Input.GetButton("Fire2") && isReloading != true)
            return true;
        else
            return false;
    }
}
