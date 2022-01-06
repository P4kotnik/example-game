using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WARecoilManager : MonoBehaviour
{
    public WAShootingMachineGun wAShootingMachineGun;

    [Header("Recoil Transform")]
    public Transform recoilRotationTransform;

    [Header("Recoil Settings")]
    public float rotationDampTime;
    [Space(10)]
    public float recoil1;
    [Space(10)]
    public Vector3 recoilRotation;
    [Space(10)]
    public Vector3 currentRecoil;
    [Space(10)]
    public Vector3 rotationOutput;

    // Update is called once per frame
    void FixedUpdate()
    {

        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, recoil1 * Time.deltaTime);

        rotationOutput = Vector3.Slerp(rotationOutput, currentRecoil, rotationDampTime * Time.fixedDeltaTime);
        recoilRotationTransform.localRotation = Quaternion.Euler(rotationOutput);
    }

    public void Fire()
    {
        currentRecoil += new Vector3(Random.Range(-recoilRotation.x, recoilRotation.x), Random.Range(-recoilRotation.y, recoilRotation.y), Random.Range(-recoilRotation.z, recoilRotation.z));
    }
}
