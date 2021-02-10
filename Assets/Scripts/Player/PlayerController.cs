using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;

    public bool isGrounded;
    public bool isMoving;

    private CharacterController controller;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        if (controller.velocity.x != 0 || controller.velocity.z != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
