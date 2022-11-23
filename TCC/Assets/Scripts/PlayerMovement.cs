using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public float gravity = -1.81f;
    public float jumpHeight = 3f;

    public float jumpCooldown = 1.6f;
    public float jumpC;

    public bool noJumping;
    Vector3 velocity;
    void Start()
    {
        noJumping = false;
    }
    void Update()
    {
        if (noJumping == false)
        {
            jumpC += Time.deltaTime;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && jumpC >= jumpCooldown)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpC = 0;
        }
        if (Input.GetButtonDown("Jump") && transform.position.y <= -1)
        {
            jumpC = 0;
            noJumping = true;
        }
    }
}
