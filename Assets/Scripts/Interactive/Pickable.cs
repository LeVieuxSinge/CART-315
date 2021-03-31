using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public bool active = true;

    private bool isHeld = false;
    private bool playerInRange = false;

    private GameInstance GameInstance;
    private Rigidbody Rigidbody;
    private GameObject Player;
    private TMPro.TextMeshPro TextMesh;
    private PlayerController PlayerController;
    private SphereCollider Trigger;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        Rigidbody = GetComponent<Rigidbody>();
        Player = Globals.GetPlayer();
        TextMesh = GetComponentInChildren<TMPro.TextMeshPro>();
        PlayerController = Player.GetComponent<PlayerController>();

        // Create trigger collider on item
        Trigger = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        Trigger.radius = 2;
        Trigger.center = new Vector3(0, 1f, 0);
        Trigger.isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active && GameInstance.GameRunning)
        {
            if (isHeld)
            {
                // Update position
                transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y + 2, Player.transform.position.z);

                // Show text
                TextMesh.alpha = 1;

                // Release with Q
                if (Input.GetKey("q"))
                {
                    Release();
                }
            }

            else if (!PlayerController.isHolding)
            {

                // Pick up with E when player in range
                if (playerInRange && Input.GetKey("e"))
                {
                    PickUp();
                }
            }
        }
    }

    public void PickUp()
    {
        PlayerController.isHolding = true;
        isHeld = true;
        TextMesh.alpha = 1;
        TextMesh.text = "Q";
        Rigidbody.isKinematic = true;
    }

    public void Release()
    {
        PlayerController.isHolding = false;
        isHeld = false;
        TextMesh.text = "E";
        TextMesh.alpha = 0;
        Rigidbody.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Player.tag)
        {
            playerInRange = true;
            TextMesh.alpha = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Player.tag)
        {
            playerInRange = false;
            TextMesh.alpha = 0;
        }
    }
}
