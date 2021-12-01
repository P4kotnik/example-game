using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdWeapon;
    public float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;

    bool canPickUp;

    // Update is called once per frame
    void Update()
    {
        CheckWeapon();

        if (canPickUp == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                {
                    Drop();
                }
                PickUpWeapon();
            }
        }

        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }
    }

    void CheckWeapon()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "pickable")
            {
                canPickUp = true;
                wp = hit.transform.gameObject;
            }
        }
        else
        {
            canPickUp = false;
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
