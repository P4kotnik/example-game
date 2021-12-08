using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShoutgun : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public ParticleSystem shotParticle;
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
        shotParticle.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
