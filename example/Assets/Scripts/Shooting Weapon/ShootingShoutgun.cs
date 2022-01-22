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
    public float dispersion = 0.2f;

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
            ShoutgunShot();
        }
    }

    void ShoutgunShot()
    {
        shotParticle.Play(); //first play particle then recoil (to improve)
        int layerMask = 1 << 7;
        layerMask = ~layerMask;

        shoutgunShot.Play(gameObject.name + "Shot");
        int i = 0;
        while (i <= 10)
        {
            Vector3 bullet = new Vector3(Random.Range(-dispersion, dispersion), Random.Range(-dispersion, dispersion), Random.Range(-dispersion, dispersion));
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward + bullet, out hit, range, layerMask))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
            i++;
        }
    }
}
