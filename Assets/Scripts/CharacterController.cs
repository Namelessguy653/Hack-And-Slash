using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Animator animator;
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Movement controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        bool isWalkingFoward = Input.GetKey(KeyCode.W);
        bool isWalkingBackwards = Input.GetKey(KeyCode.S);
        bool isWalkingRight = Input.GetKey(KeyCode.D);
        bool isWalkingLeft = Input.GetKey(KeyCode.A);

        if (Input.GetKey(KeyCode.W))
        {

            animator.SetBool("IsWalkingFoward", isWalkingFoward);
            animator.SetBool("NotWalking", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingBackwards", false);

        }
        else if (Input.GetKey(KeyCode.A))
        {

            animator.SetBool("IsWalkingLeft", isWalkingLeft);
            animator.SetBool("NotWalking", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingFoward", false);
            animator.SetBool("IsWalkingBackwards", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {

            animator.SetBool("IsWalkingRight", isWalkingRight);
            animator.SetBool("NotWalking", false);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingFoward", false);
            animator.SetBool("IsWalkingBackwards", false);

        }
        else if (Input.GetKey(KeyCode.S))
        {

            animator.SetBool("IsWalkingBackwards", isWalkingBackwards);
            animator.SetBool("NotWalking", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingFoward", false);

        }
        else
        {
            animator.SetBool("NotWalking", true);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingFoward", false);
            animator.SetBool("IsWalkingBackwards", false);

        }


    //    Jump control
    //    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //    {
    //        Debug.Log("space is pressed");
    //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }
    }
}
