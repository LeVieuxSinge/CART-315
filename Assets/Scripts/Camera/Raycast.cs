using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public Camera maincamera;

    private GameObject target;

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
                if (target)
                {
                    target = null;
                }
                else
                {
                    if (results.collider.gameObject.tag == "Food")
                    {
                        target = results.collider.gameObject;
                    }
                }
            }
        }

        if (target)
        {
            Ray moveRay = maincamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit moveResults;
            if (Physics.Raycast(moveRay, out moveResults))
            {
                //if (moveResults.collider.gameObject != target)
                //{
                //    target.transform.position = moveResults.point;
                //}
                target.transform.position = moveResults.point;
            }
        }

    }

}
