using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public float scaleSpeed = 0.1f;

    Ray ray;
    RaycastHit hit;

    private GameInstance GameInstance;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameInstance.GameRunning)
        {

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {

                    // GrowNShrink Object
                    if (hit.collider.gameObject.TryGetComponent(out GrowNShrinkObject growNShrinkObject))
                    {

                        // Null if both keys are pressed
                        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
                        {
                            return;
                        }

                        // Scale up if left click
                        if (Input.GetMouseButton(0))
                        {
                            growNShrinkObject.ScaleUp(scaleSpeed);
                        }

                        // Scale down if right click
                        if (Input.GetMouseButton(1))
                        {
                            growNShrinkObject.ScaleDown(scaleSpeed);
                        }

                    }

                    // GrowNShrink Object
                    if (hit.collider.gameObject.TryGetComponent(out GrowNShrinkLight growNShrinkLight))
                    {

                        // Null if both keys are pressed
                        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
                        {
                            return;
                        }

                        // Scale up if left click
                        if (Input.GetMouseButton(0))
                        {
                            growNShrinkLight.ScaleUp(scaleSpeed);
                        }

                        // Scale down if right click
                        if (Input.GetMouseButton(1))
                        {
                            growNShrinkLight.ScaleDown(scaleSpeed);
                        }

                    }

                }

            }

        }

    }

}
