using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Atributs")]
    public float speed = 10f;

    [Header("Jump, Gravity")]
    public float gravity = -9.81f;
    public Transform groundCheck;
    public bool isGround;
    public float groundDistance = 0.4f;
    public float maxJumpHeight = 2f;
    public LayerMask groundMask;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = (transform.right * x) + (transform.forward * z);
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGround && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(maxJumpHeight * -2 * gravity);
        }
    }
}
