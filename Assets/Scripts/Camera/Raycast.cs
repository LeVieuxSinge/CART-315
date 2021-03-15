using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public float scaleMultiplier = 10f;
    public float maxScale = 5f;

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

            float scroll = Input.mouseScrollDelta.y / scaleMultiplier;

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag == "Scalable")
                    {

                        Transform transform = hit.collider.gameObject.transform;

                        float scale = 0.0f;

                        if (Input.GetMouseButton(0))
                        {
                            scale = Mathf.Min(transform.localScale.x + scaleMultiplier, maxScale);
                        }

                        if (Input.GetMouseButton(1))
                        {
                            scale = Mathf.Max(transform.localScale.x - scaleMultiplier, 1);
                        }

                        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
                        {
                            scale = Mathf.Max(transform.localScale.x);
                        }

                        transform.localScale = new Vector3(scale, scale, scale);

                    }
                }

            }

        }

    }

}
