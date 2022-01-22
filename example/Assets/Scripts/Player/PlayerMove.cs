using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    public GetInformation getInformation;

    [Header("Atributs")]
    public float speed = 10f;
    public float sprint = 20f;
    public float scopedSpeed = 5f;
    float defaultSpeed;
    [Space(10)]
    public KeyCode sprintKey;

    [Header("Jump, Gravity")]
    public float gravity = -19.62f;
    public Transform groundCheck;
    bool isGround;
    public float groundDistance = 0.4f;
    public float maxJumpHeight = 2f;
    public LayerMask groundMask;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        getInformation.isGround = isGround;

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //move
        Vector3 move = (transform.right * x) + (transform.forward * z);
        characterController.Move(move * speed * Time.deltaTime);
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && isGround == true)
        {
            getInformation.isMove = true;
        }
        else
        {
            getInformation.isMove = false;
        }
        Sprint();
        Scope();

        //gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGround && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(maxJumpHeight * -2 * gravity);
        }
    }

    void Sprint()
    {
        if (Input.GetKey(sprintKey) && getInformation.isMove == true)
        {
            speed = sprint;
            getInformation.isSprint = true;
        }
        else
        {
            speed = defaultSpeed;
            getInformation.isSprint = false;
        }
    }

    void Scope()
    {
        if (getInformation.isScoped == true && getInformation.isSprint == false)
        {
            speed = scopedSpeed;
        }
    }
}
