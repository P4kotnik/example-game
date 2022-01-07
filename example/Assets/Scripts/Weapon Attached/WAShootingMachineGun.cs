using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAShootingMachineGun : MonoBehaviour
{
    public InterationMeneger interationMeneger;
    public WARecoilManager wARecoilManager;
    float currentSize;
    public ParticleSystem shotParticle;
    public GameObject impactEffect;
    GetInformation getInformation;

    public Camera fpsCamera;
    bool isInteraction;

    public float range = 100f;
    public float damage = 10f;

    public float fireRate;
    float fireTimer;

    [Header("For crosshair")]
    public float scaleForCrosshair;
    public float waitTimeForCrosshair;

    bool readyToShot;

    private void Start()
    {
        getInformation = GameObject.Find("PlayerObject").GetComponent<GetInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        isInteraction = interationMeneger.isInteraction;
        if (isInteraction)
        {
            getInformation.scaleForCrosshair = scaleForCrosshair;
            getInformation.smouthTimeForCrosshair = waitTimeForCrosshair;
            if (Input.GetButton("Fire1") && readyToShot == true)
            {
                getInformation.shot = true;

                currentSize = GameObject.Find("Crosshair").GetComponent<Crosshair>().currentSize;
                Shooting();
                wARecoilManager.Fire();
                fireTimer = fireRate;
                readyToShot = false;
            }
            else
            {
                getInformation.shot = false;
            }
        }

        if (fireTimer >= 0)
        {
            fireTimer -= Time.deltaTime;
        }
        else
        {
            readyToShot = true;
        }

        InterationLayer();
    }

    void Shooting()
    {
        int layerMask = 1 << 7;

        layerMask = ~layerMask;
        shotParticle.Play();
        RaycastHit hit;
        Vector3 bulletDispersion = new Vector3(Random.Range(-dispersion(), dispersion()), Random.Range(-dispersion(), dispersion()), Random.Range(-dispersion(), dispersion()));
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward + bulletDispersion, out hit, range, layerMask))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    public float dispersion()
    {
        return currentSize / 1000 / 1.5f; //currentSize=100, dispersion~0.07
    }

    void InterationLayer()
    {
        if (isInteraction == true)
        {
            gameObject.layer = 7;
        }
        else
        {
            gameObject.layer = 0; 
        }
    }
}
