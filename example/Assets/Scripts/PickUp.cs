using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject objectInSight;
    public KeyCode pickUpKey;
    public KeyCode dropKey;

    public float distance = 10f;

    [Header("For weapon")]
    public WeaponsMenager weaponsMenager;
    public Transform holdWeapon;
    public GameObject currentWeapon;
    GameObject wp;

    //bool canPickUp;

    // Update is called once per frame
    void Update()
    {
        objectInSight = Check();
        if (objectInSight == null)
            return;

        if (objectInSight.tag == "pickable")
        {
            wp = objectInSight.transform.gameObject;

            if (Input.GetKeyDown(pickUpKey))
            {
                if (currentWeapon != null && weaponsMenager.secondWeapon != null)
                {
                    Drop();
                    weaponsMenager.currentWeaponInHands = null;
                    PickUpWeapon();
                    weaponsMenager.currentWeaponInHands = currentWeapon;
                }
                else if (currentWeapon != null && weaponsMenager.secondWeapon == null)
                {
                    weaponsMenager.secondWeapon = currentWeapon;
                    PickUpWeapon();
                    weaponsMenager.currentWeaponInHands = currentWeapon;
                }
                else
                {
                    PickUpWeapon();
                    weaponsMenager.currentWeaponInHands = currentWeapon;
                }
            }
        }

        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(dropKey))
            {
                Drop();
                weaponsMenager.currentWeaponInHands = weaponsMenager.secondWeapon;
                weaponsMenager.secondWeapon = null;
                currentWeapon = weaponsMenager.currentWeaponInHands;
            }
        }
    }

    GameObject Check()
    {
        int layerMask = 1 << 7;

        layerMask = ~layerMask;
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance, layerMask))
        {
            if (hit.transform.tag == "pickable")
            {
                //canPickUp = true;
                wp = hit.transform.gameObject;

                return wp;
            }
            return hit.transform.gameObject;
        }
        else
        {
            //canPickUp = false;
            return wp;
        }
    }

    void PickUpWeapon()
    {
        currentWeapon = wp;
        currentWeapon.transform.position = holdWeapon.position;
        currentWeapon.transform.parent = holdWeapon;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}
