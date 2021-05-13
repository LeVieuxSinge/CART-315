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
    private Material Material;
    private List<GameObject> nearAbsorbers;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        Light = gameObject.GetComponentInChildren<Light>();
        Material = gameObject.transform.GetChild(0).GetComponent<Renderer>().material;

        Light.intensity = energy;
        Light.range = energy;
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
                Material.SetColor("_EmissionColor", Material.color * energy);
            }

            // Charge absorbers around
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Interactive"))
            {
                if (item.TryGetComponent(out Absorber absorber))
                {
                    if (Vector3.Distance(transform.position + (transform.localScale / 2), item.transform.position) <= energy)
                        item.GetComponent<Absorber>().ChargeEnergy();
                }
            }

            // Lose power
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
