using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNormal : MonoBehaviour
{
    float currentSize;
    public WeaponInfo weaponInfo;
    public ParticleSystem shotParticle;
    public GameObject impactEffect;
    WeaponsMenager weaponsMenager;
    Camera fpsCamera;
    bool isEquipment;
    public Animation weaponAnimations;

    public float range = 100f;
    public float damage = 10f;

    void Start()
    {
        fpsCamera = GameObject.Find("Camera").GetComponent<Camera>();
        weaponsMenager = GameObject.Find("WeaponMenager").GetComponent<WeaponsMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        isEquipment = weaponInfo.isEquipment;
        if (isEquipment && weaponsMenager.getInformation.shot)
        {
            currentSize = GameObject.Find("Crosshair").GetComponent<Crosshair>().currentSize;
            Shooting();
        }
        
    }

    void Shooting()
    {
        weaponAnimations.Play(gameObject.name + "Shooting");
        
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
        if (weaponsMenager.getInformation.isScoped)
            return 0;
        else
            return currentSize/1000/2f; //currentSize=100, dispersion~0.05
    }
}
