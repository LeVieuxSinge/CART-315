using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallReset : MonoBehaviour
{

    public GameObject player;

    MeshCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().resetPosition();
        }
    }
}
