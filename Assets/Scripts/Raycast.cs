using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public Camera maincamera;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        if (Input.GetMouseButton(0))
        {
            Ray clickray = maincamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit results;
            if (Physics.Raycast(clickray, out results))
            {
                GameObject.Instantiate(prefab, results.point, Quaternion.identity);
            }
        }

    }

}
