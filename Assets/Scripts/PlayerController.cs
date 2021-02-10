using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 9.8f;

    public Transform resetTransform;

    CharacterController controller;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check ground condition
        if (controller.isGrounded)
        {

            // Move player
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            velocity *= speed;

            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
            }
        }

        // Update position
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void resetPosition()
    {
        transform.position = resetTransform.position;
    }
}
