using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedMultiplier = 1.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;

    public float maxScale = 1;
    public float minScale = 0.5f;

    public bool isGrounded;
    public bool isMoving;
    public bool isHolding;

    private GameInstance GameInstance;
    private CharacterController controller;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (GameInstance.GameRunning)
        {
            // Grounded status
            isGrounded = controller.isGrounded;

            // Gravity stop
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            // Move player
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            controller.Move(move * Time.deltaTime * (GameInstance.GameSpeed * speedMultiplier));

            // Moving animation state
            if (controller.velocity.x != 0 || controller.velocity.z != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            // Forward vector
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButton("Jump") && isGrounded && !isHolding)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }

            // Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }

    }

}
