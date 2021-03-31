using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

    public bool canBeScaled = false;
    public bool canBePickedUp = false;
    public bool isLight = false;
    public bool absorbLight = false;
    public float maxScale = 10.0f;
    public float minScale = 1.0f;
    public float lightEnergy = 0f;

    private bool isHold = false;
    private bool playerInRange = false;

    private GameInstance GameInstance;
    private GameObject Player;
    private TMPro.TextMeshPro TextMesh;
    private SphereCollider InteractionCollider;
    private Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        Player = Globals.GetPlayer();
        TextMesh = GetComponentInChildren<TMPro.TextMeshPro>();
        Rigidbody = GetComponent<Rigidbody>();

        // Create trigger collider on item
        InteractionCollider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        InteractionCollider.radius = 2;
        InteractionCollider.center = new Vector3(0, 1f, 0);
        InteractionCollider.isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("e") && canBePickedUp && playerInRange && !Player.GetComponent<PlayerController>().isHolding)
        {
            Deactivate();
            Player.GetComponent<PlayerController>().isHolding = true;
        }

        if (isHold)
        {
            transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y + 3, Player.transform.position.z);
        }

        if (isLight)
        {
            // Lose power
            // Decrease light intensity and range
            gameObject.GetComponentInChildren<Light>().intensity = Mathf.Max(gameObject.GetComponentInChildren<Light>().intensity - 0.05f, minScale);
            gameObject.GetComponentInChildren<Light>().range = Mathf.Max(gameObject.GetComponentInChildren<Light>().range - 0.05f, minScale);
            // Decrease hit box
            gameObject.GetComponent<SphereCollider>().radius = Mathf.Max(gameObject.GetComponent<SphereCollider>().radius - 0.05f, minScale);
            // Decrease material emissive
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color * gameObject.GetComponentInChildren<Light>().intensity);
        }

        if (absorbLight)
        {
            lightEnergy = Mathf.Max(lightEnergy - 0.01f, minScale);
            // Increase material emissive
            gameObject.transform.GetChild(0).GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color * lightEnergy);
            gameObject.transform.GetChild(0).GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color * lightEnergy);
        }
    }

    public void Deactivate()
    {
        isHold = true;
        TextMesh.text = "Q";
        Rigidbody.isKinematic = true;
    }

    public void Activate()
    {
        isHold = false;
        TextMesh.text = "E";
        Rigidbody.isKinematic = false;
    }

    public void ScaleUp(float speed)
    {
        if (canBeScaled && GameInstance.GameRunning)
        {
            if (!isLight)
            {
                float scale = 0.0f;
                scale = Mathf.Min(transform.localScale.x + speed, maxScale);
                transform.localScale = new Vector3(scale, scale, scale);
                Rigidbody.mass = scale;
            }
            else
            {
                // Increase light intensity and range
                gameObject.GetComponentInChildren<Light>().intensity = Mathf.Min(gameObject.GetComponentInChildren<Light>().intensity + 0.1f, maxScale);
                gameObject.GetComponentInChildren<Light>().range = Mathf.Min(gameObject.GetComponentInChildren<Light>().range + 0.1f, maxScale);
                // Increase hit box
                gameObject.GetComponent<SphereCollider>().radius = Mathf.Min(gameObject.GetComponent<SphereCollider>().radius + 0.1f, maxScale);
                // Increase material emissive
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color * gameObject.GetComponentInChildren<Light>().intensity);
            }
        }
    }

    public void ScaleDown(float speed)
    {
        if (canBeScaled && GameInstance.GameRunning)
        {
            if (!isLight)
            {
                float scale = 0.0f;
                scale = Mathf.Max(transform.localScale.x - speed, minScale);
                transform.localScale = new Vector3(scale, scale, scale);
                Rigidbody.mass = scale;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            if (canBePickedUp && !isHold)
            {
                playerInRange = true;
                TextMesh.alpha = 1;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (absorbLight && other.gameObject.GetComponent<Interactive>().isLight)
        {
            lightEnergy = Mathf.Min(lightEnergy + 0.05f, maxScale);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            if (canBePickedUp && !isHold)
            {
                playerInRange = false;
                TextMesh.alpha = 0;
            }
        }
    }
}
