using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsMenager : MonoBehaviour
{
    public GameObject currentWeaponInHands;
    public GameObject secondWeapon;
    public PickUp pickUp;
    // Start is called before the first frame update
    void Start()
    {
        currentWeaponInHands = pickUp.currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeaponInHands != null && secondWeapon == null)
        {
            currentWeaponInHands.SetActive(true);
        }
        else if (currentWeaponInHands != null && secondWeapon != null)
        {
            currentWeaponInHands.SetActive(true);
            secondWeapon.SetActive(false);
        }
    }
}
