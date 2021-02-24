using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePlatform : MonoBehaviour
{

    public GameObject CameraObject;
    public float rotationSpeed = 2f;

    private GameInstance GameInstance;
    private Camera cameraComponent;
    private Vector3 mousePosition;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        cameraComponent = CameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameInstance.GameRunning)
        {
            // Get mouse position on screen
            mousePosition = Input.mousePosition;

            // Set camera depth
            mousePosition.z = -CameraObject.transform.position.z;

            // Convert to world space
            mousePosition = cameraComponent.ScreenToWorldPoint(mousePosition);

            // Move object
            transform.position = mousePosition;

            // Rotate object with A and D keys
            if (Input.GetKey("a"))
            {
                rotation.z = -rotationSpeed;
            }

            if (Input.GetKey("d"))
            {
                rotation.z = rotationSpeed;
            }

            if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                rotation.z = 0;
            }

            Quaternion deltaRotation = Quaternion.Euler(rotation);

            // Rotate object
            transform.rotation = transform.rotation * deltaRotation;
        }
    }
}
