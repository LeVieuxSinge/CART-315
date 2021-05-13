using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorber : MonoBehaviour
{

    public bool active = true;
    public float energy = 0.0f;
    public float energyGain = 0.05f;
    public float energyLoss = 0.01f;
    public float maxScale = 10.0f;
    public float minScale = 1.0f;

    private GameInstance GameInstance;
    private Material[] Material;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        Material = gameObject.transform.GetChild(0).GetComponent<Renderer>().materials;

        foreach (Material material in Material)
        {
            material.SetColor("_EmissionColor", material.color * energy);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active && GameInstance.GameRunning)
        {

            // Update components only when energy higher than minimum
            if (energy > minScale)
            {
                foreach(Material material in Material)
                {
                    material.SetColor("_EmissionColor", material.color * energy);
                }
            }

            // Lose power
            //Debug.Log(energy);
            energy = Mathf.Max(energy - energyLoss, minScale);

        }
    }

    public void ChargeEnergy()
    {
        if (active && GameInstance.GameRunning)
        {
            energy = Mathf.Min(energy + energyGain, maxScale);
        }
    }
}
