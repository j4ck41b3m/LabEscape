using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 300f;
    public LayerMask groundMask;

    public bool isSprinting;
    public float sprintingSpeedMultiplier = 5f;
    public float sprintSpeed = 1f;

    public float staminaUseAmount = 5;
    private Slide staminaSlider;

    //GroundCheck

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
     bool isGrounded;

Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        //Gravedad

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //GroundCheck

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
       
        

        //Salto

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * Time.deltaTime);
        }
    }

    private void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isSprinting = !isSprinting;
            if (isSprinting)
            {
                staminaSlider.UseStamina(staminaUseAmount);
            }
            else
            {
                staminaSlider.UseStamina(0);
            }

        }
    }
}
