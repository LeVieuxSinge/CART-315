using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{

    public bool active = true;

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

    private void OnTriggerEnter(Collider other)
    {
        if (active && GameInstance.GameRunning)
        {
            if (other.gameObject.tag == Globals.GetPlayer().tag)
            {
                Globals.GetPlayer().GetComponent<GrowNShrinkObject>().active = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (active && GameInstance.GameRunning)
        {
            if (other.gameObject.tag == Globals.GetPlayer().tag)
            {
                Globals.GetPlayer().GetComponent<GrowNShrinkObject>().active = false;
            }
        }
    }
}
