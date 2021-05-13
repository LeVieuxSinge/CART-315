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
            // Cannot scale up when held
            if (gameObject.TryGetComponent(out Pickable pickable))
            {
                if (pickable.isHeld)
                    return;
            }

            // Calculate scale
            float scaleX = Mathf.Min(transform.localScale.x + speed, maxScale); ;
            float scaleY = Mathf.Min(transform.localScale.y + speed, maxScale); ;
            float scaleZ = Mathf.Min(transform.localScale.z + speed, maxScale); ;

            if (lockX)
                scaleX = transform.localScale.x ;
            if (lockY)
                scaleY = transform.localScale.y;
            if (lockZ)
                scaleZ = transform.localScale.z;

            // Aplly new scale and mass
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            if (Rigidbody)
            {
                Rigidbody.mass = Mathf.Max(scaleX, scaleY, scaleZ);
            }
        }
    }

    public void ScaleDown(float speed)
    {
        if (active && GameInstance.GameRunning)
        {
            // Cannot scale down when held
            if (gameObject.TryGetComponent(out Pickable pickable))
            {
                if (pickable.isHeld)
                    return;
            }

            // Calculate scale
            float scaleX = Mathf.Max(transform.localScale.x - speed, minScale); ;
            float scaleY = Mathf.Max(transform.localScale.y - speed, minScale); ;
            float scaleZ = Mathf.Max(transform.localScale.z - speed, minScale); ;

            if (lockX)
                scaleX = transform.localScale.x;
            if (lockY)
                scaleY = transform.localScale.y;
            if (lockZ)
                scaleZ = transform.localScale.z;

            // Aplly new scale and mass
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            if (Rigidbody)
            {
                Rigidbody.mass = Mathf.Min(scaleX, scaleY, scaleZ);
            }
        }
    }
}
