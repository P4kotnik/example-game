using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickItemUI : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Transform ItemPickUI;

    public PickUp pickUp;

    // Update is called once per frame
    void Update()
    {
        if (pickUp.objectInSight != null && pickUp.objectInSight.tag == "pickable")
        {
            ItemPickUI.gameObject.SetActive(true);
            itemName.text = "Pick: " + pickUp.objectInSight.GetComponent<Pickable>().nameForUI;
        }
        else if (pickUp.objectInSight != null && pickUp.objectInSight.tag == "interation")
        {
            ItemPickUI.gameObject.SetActive(true);
            itemName.text = "Interact with: " + pickUp.objectInSight.GetComponent<Interation>().nameForUI;
        }
        else
        {
            ItemPickUI.gameObject.SetActive(false);
        }
    }
}
