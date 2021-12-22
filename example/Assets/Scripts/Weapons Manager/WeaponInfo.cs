using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    [Header("WeaponInfo recoil rotation:x - kickBack up")]
    public Vector3 recoilRotation;
    [Header("WeaponInfo recoil rotation:z - kickBack back")]
    public Vector3 recoilKickBack;

    public Sprite weaponImage;
    public Transform leftHand;
    public Transform rightHand;
    public Animation weaponAnimation;

    public int magazineCapacity;
    public int currentMagazineCapacity;
    public int maxNumberOfMagazins;
    public int currentNumberOfMagazins;

    public float fireRate;
    public string typeOfWeapon;

    public float dispersion;

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
            gameObject.layer = 7;
            return true;
        }
        gameObject.layer = 0;
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
        weaponAnimation.Play(gameObject.name + "Reload");
         yield return new WaitUntil(() => !weaponAnimation.isPlaying); 

        currentMagazineCapacity = magazineCapacity;
        currentNumberOfMagazins--;
    }
}
