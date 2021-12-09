using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    public WeaponsMenager weaponsMenager;

    public GameObject leftHand;
    public GameObject rightHand;

    public Transform defaultRihtHandPosition;

    // Update is called once per frame
    void Update()
    {
        if (weaponsMenager.currentWeaponInHands == null)
        {
            leftHand.SetActive(false);
            rightHand.transform.position = defaultRihtHandPosition.position;
            rightHand.SetActive(true);
        }
        else
        {
            leftHand.SetActive(true);
            leftHand.transform.position = weaponsMenager.currentWeaponInHands.GetComponent<WeaponInfo>().leftHand.position;
            rightHand.transform.position = weaponsMenager.currentWeaponInHands.GetComponent<WeaponInfo>().rightHand.position;
        }
    }
}
