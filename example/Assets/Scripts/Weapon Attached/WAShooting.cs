using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAShooting : MonoBehaviour
{
    PickUp pickUp;
    public RecoilScript recoilScript;
    public GameObject crosshair;
    public ParticleSystem shotParticle;
    public GameObject impactEffect;
    Camera fpsCamera;

    public float range = 100f;
    public float damage = 10f;

    public Sprite weaponImage;

    public float fireRate;

    public float scaleForCrosshair;
    public float waitTimeForCrosshair;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = GameObject.Find("Player").GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.interactWithItem == true)
        {
            Shooting();
        }
    }

    void Shooting()
    { 
        
    }
}
