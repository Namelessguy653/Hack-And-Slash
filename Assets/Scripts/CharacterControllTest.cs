using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllTest : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Transform cameraTransform;
    [SerializeField]
    private float timesSwordSwung = 0;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isSwingingSword = false; // New variable to track sword swinging state

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Movement
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Animation
        bool isWalkingForward = Input.GetKey(KeyCode.W);
        bool isWalkingBackwards = Input.GetKey(KeyCode.S);
        bool isWalkingRight = Input.GetKey(KeyCode.D);
        bool isWalkingLeft = Input.GetKey(KeyCode.A);

        // Set walking animation parameters
        animator.SetBool("IsWalkingFoward", isWalkingForward);
        animator.SetBool("IsWalkingBackwards", isWalkingBackwards);
        animator.SetBool("IsWalkingRight", isWalkingRight);
        animator.SetBool("IsWalkingLeft", isWalkingLeft);
        animator.SetBool("NotWalking", !isWalkingForward && !isWalkingBackwards && !isWalkingRight && !isWalkingLeft);

        // Set swinging sword animation parameter
        animator.SetBool("IsSwingingSword", isSwingingSword);

        if (moveHorizontal != 0)
        {
            // Rotate the character model
            transform.Rotate(0f, moveHorizontal * rotationSpeed * Time.deltaTime, 0f);

            // Rotate the camera around the character
            cameraTransform.RotateAround(transform.position, Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
        }

        // Set isSwingingSword bool based on Fire1 button press
        if (Input.GetButtonDown("Fire1"))
        {
            timesSwordSwung ++;
            GameAnalytics.NewDesignEvent("OnSwing", timesSwordSwung);
            isSwingingSword = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isSwingingSword = false;
        }

        // Rotation
        if (!isSwingingSword && moveHorizontal != 0)
        {
            transform.Rotate(0f, moveHorizontal * rotationSpeed * Time.deltaTime, 0f);
            cameraTransform.RotateAround(transform.position, Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
        }

        // Jump control
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
