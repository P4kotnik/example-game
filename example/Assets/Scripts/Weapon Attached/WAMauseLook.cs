using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAMauseLook : MonoBehaviour
{
    [Header("Atributs")]
    public float mouseSensitivity = 100f;

    [Header("other")]
    public Transform weapon;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -20, 20);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -60, 60);

        weapon.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
