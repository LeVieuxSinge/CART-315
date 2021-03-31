using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowNShrinkObject : MonoBehaviour
{

    public bool active = true;
    public float maxScale = 10.0f;
    public float minScale = 1.0f;
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    private GameInstance GameInstance;
    private Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void ScaleUp(float speed)
    {
        if (active && GameInstance.GameRunning)
        {
            // Calculate scale
            float scale = 0.0f;
            scale = Mathf.Min(transform.localScale.x + speed, maxScale);

            float scaleX = scale;
            float scaleY = scale;
            float scaleZ = scale;

            if (lockX)
                scaleX = transform.localScale.x ;
            if (lockY)
                scaleY = transform.localScale.y;
            if (lockZ)
                scaleZ = transform.localScale.z;

            // Aplly new scale and mass
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            Rigidbody.mass = scale;
        }
    }

    public void ScaleDown(float speed)
    {
        if (active && GameInstance.GameRunning)
        {
            // Calculate scale
            float scale = 0.0f;
            scale = Mathf.Max(transform.localScale.x - speed, minScale);

            float scaleX = scale;
            float scaleY = scale;
            float scaleZ = scale;

            if (lockX)
                scaleX = transform.localScale.x;
            if (lockY)
                scaleY = transform.localScale.y;
            if (lockZ)
                scaleZ = transform.localScale.z;

            // Aplly new scale and mass
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            Rigidbody.mass = scale;
        }
    }
}
