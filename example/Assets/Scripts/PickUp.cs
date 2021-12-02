using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Pick up settings")]
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
        Debug.Log(objectInSight.name);
        if (objectInSight == null)
            return;

        if (objectInSight.tag == "pickable")
        {
            wp = objectInSight.transform.gameObject;

            if (Input.GetKeyDown(pickUpKey)) // wsadzic do void, id w osobnym skrypcie
            {
                if (currentWeapon != null)
                {
                    if (weaponsMenager.secondWeapon != null)
                    {
                        Drop();
                        weaponsMenager.currentWeaponInHands = null;
                        PickUpWeapon();
                        weaponsMenager.currentWeaponInHands = currentWeapon;
                    }
                    else
                    {
                        weaponsMenager.secondWeapon = currentWeapon;
                        PickUpWeapon();
                        weaponsMenager.currentWeaponInHands = currentWeapon;
                    }
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

                return hit.transform.gameObject;
            }
            return hit.transform.gameObject;
        }
        else
        {
            //canPickUp = false;
            return hit.transform.gameObject;
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
