using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShoutgun : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public ParticleSystem shotParticle;
    public GameObject impactEffect;
    public Animation shoutgunShot;
    WeaponsMenager weaponsMenager;
    Camera fpsCamera;
    bool isEquipment;

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
        if (isEquipment && weaponsMenager.isShot)
        {
            ShoutgunShot();
        }
    }

    void ShoutgunShot()
    {
        shotParticle.Play(); //first play particle then recoil (to improve)
        int layerMask = 1 << 7;

        layerMask = ~layerMask;
        shoutgunShot.Play(gameObject.name + "Shot");
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, layerMask))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
