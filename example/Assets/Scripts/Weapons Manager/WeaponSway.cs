using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway settings")]
    [SerializeField] float smouth;
    [SerializeField] float swayMultipler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultipler;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultipler;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smouth * Time.deltaTime);
    }
}
