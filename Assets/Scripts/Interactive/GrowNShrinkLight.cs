using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowNShrinkLight : MonoBehaviour
{

    public bool active = true;
    public float energy = 0.0f;
    public float energyLoss = 0.01f;
    public float maxScale = 10.0f;
    public float minScale = 1.0f;

    private GameInstance GameInstance;
    private Light Light;
    private SphereCollider Trigger;
    private Material Material;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        Light = gameObject.GetComponentInChildren<Light>();
        Trigger = GetComponent<SphereCollider>();
        Material = gameObject.transform.GetChild(0).GetComponent<Renderer>().material;

        Light.intensity = energy;
        Light.range = energy;
        Trigger.radius = energy;
        Material.SetColor("_EmissionColor", Material.color * energy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active && GameInstance.GameRunning)
        {

            // Update components only when energy higher than minimum
            if (energy > minScale)
            {
                Light.intensity = energy;
                Light.range = energy;
                Trigger.radius = energy;
                Material.SetColor("_EmissionColor", Material.color * energy);
            }

            // Lose power
            Debug.Log(energy);
            energy = Mathf.Max(energy - energyLoss, minScale);

        }
    }

    public void ScaleUp(float speed)
    {
        if (active && GameInstance.GameRunning)
        {
            // Calculate energy
            energy = Mathf.Min(energy + speed, maxScale);
        }
    }

    public void ScaleDown(float speed)
    {
        if (active && GameInstance.GameRunning)
        {
            // Calculate energy
            energy = Mathf.Max(energy - speed, minScale);
        }
    }
}
