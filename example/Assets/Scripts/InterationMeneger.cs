using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterationMeneger : MonoBehaviour
{
    public GameObject player;
    public GetInformation getInformation;
    KeyCode pickKey;

    public bool isInteraction;
    // Start is called before the first frame update
    void Start()
    {
        pickKey = player.GetComponent<PickUp>().pickUpKey;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pickKey) && player.GetComponent<PickUp>().interactWithItem == true && isInteraction == false)
        {
            player.SetActive(false);
            isInteraction = true;
            getInformation.isMove = false;
            getInformation.isSprint = false;
        }
        else if (Input.GetKeyDown(pickKey) && isInteraction == true)
        {
            player.SetActive(true);
            isInteraction = false;
        }
    }
}
