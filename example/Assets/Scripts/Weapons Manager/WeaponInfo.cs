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

    [Space(10)]
    public Sprite weaponImage;
    public Transform leftHand;
    public Transform rightHand;
    public Animation weaponAnimation;

    [Header("Bullets")]
    public int magazineCapacity;
    public int currentMagazineCapacity;

    [Header("Magazines")]
    public int maxNumberOfMagazines;
    public int currentNumberOfMagazines;

    [Space(10)]
    //fire rate
    public float fireRate;
    //weapon type
    public string typeOfWeapon;

    [Space(10)]
    //crosshair
    public float scaleForCrosshair;
    public float waitTimeForCrosshair;

    [Space(10)]
    public bool isEquipment;

    private void Start()
    {
        currentMagazineCapacity = magazineCapacity;
        currentNumberOfMagazines = maxNumberOfMagazines;
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
        if (GameObject.Find("Player") != null)
        {
            if (transform.IsChildOf(GameObject.Find("Player").transform))
            {
                gameObject.layer = 7; //player's layer
                return true;
            }
        }
        gameObject.layer = 0; //default layer
        return false;
    }

    public void Reloading() //do poprawa
    {
        if (currentNumberOfMagazines > 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        weaponAnimation.Play(gameObject.name + "Reload");
        yield return new WaitUntil(() => !weaponAnimation.isPlaying);

        currentMagazineCapacity = magazineCapacity;
        currentNumberOfMagazines--;
    }
}
