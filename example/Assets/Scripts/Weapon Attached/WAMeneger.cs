using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAMeneger : MonoBehaviour
{
    InterationMeneger interationMeneger;
    public Camera cameraComponent;
    public WAMauseLook wAMauseLook;

    // Start is called before the first frame update
    void Start()
    {
        interationMeneger = GameObject.Find("InterationObject").GetComponent<InterationMeneger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interationMeneger.isInteraction == true)
        {
            cameraComponent.enabled = true;
            wAMauseLook.enabled = true;
        }
        else
        {
            cameraComponent.enabled = false;
            wAMauseLook.enabled = false;
        }
        //if (pickUp.interactWithItem == true)
        //{
        //    cameraComponent.enabled = true;
        //    wAMauseLook.enabled = true;
        //    isInteraction = true;
        //}
        //else if(isInteraction == true)
        //{
        //    cameraComponent.enabled = false;
        //    wAMauseLook.enabled = false;
        //}
    }
}
