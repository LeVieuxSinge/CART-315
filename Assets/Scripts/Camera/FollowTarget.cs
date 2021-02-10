using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public GameObject target;

    private Vector3 savedPosition;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        savedPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPosition = savedPosition + target.transform.position;
        transform.position = newPosition;
    }
}
