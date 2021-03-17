using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour
{

    public float maxScale = 10.0f;
    public float minScale = 1.0f;

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
        
    }

    public void ScaleUp(float speed)
    {
        if (GameInstance.GameRunning)
        {
            float scale = 0.0f;
            scale = Mathf.Min(transform.localScale.x + speed, maxScale);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void ScaleDown(float speed)
    {
        if (GameInstance.GameRunning)
        {
            float scale = 0.0f;
            scale = Mathf.Max(transform.localScale.x - speed, minScale);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
