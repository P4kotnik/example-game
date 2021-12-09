using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public Sprite weaponImage;

    public int magazineCapacity;
    public int currentMagazineCapacity;
    public int maxNumberOfMagazins;
    public int currentNumberOfMagazins;

    public float fireRate;
    public string typeOfWeapon;

    public bool isEquipment;

    private void Start()
    {
        currentMagazineCapacity = magazineCapacity;
        currentNumberOfMagazins = maxNumberOfMagazins;
    }

    private void Update()
    {
        isEquipment = Equipment();

        if (!isEquipment)
        {
            return;
        }
    }

    bool Equipment()
    {
        if (transform.IsChildOf(GameObject.Find("Player").transform))
        {
            return true;
        }
        return false;
    }

    public void Reloading()
    {
        if (currentNumberOfMagazins > 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1); //give animation

        currentMagazineCapacity = magazineCapacity;
        currentNumberOfMagazins--;
    }
}
