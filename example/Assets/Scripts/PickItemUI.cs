using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItemUI : MonoBehaviour
{
    public Image ItemInSight;
    public Transform ItemPickUI;

    public PickUp pickUp;

    // Update is called once per frame
    void Update()
    {
        if (pickUp.objectInSight != null && pickUp.objectInSight.tag == "pickable")
        {
            ItemPickUI.gameObject.SetActive(true);
            ItemInSight.sprite = pickUp.objectInSight.GetComponent<WeaponInfo>().weaponImage;
        }
        else
        {
            ItemPickUI.gameObject.SetActive(false);
        }
    }
}
