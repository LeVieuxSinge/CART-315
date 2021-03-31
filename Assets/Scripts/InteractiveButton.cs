using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButton : MonoBehaviour
{

    public GameObject toDestroy;
    public bool checkMass = false;
    public bool checkLight = false;
    public float minimumMass = 1;
    public float minimumLight = 1;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tags>().IsTag("Interactive") && checkMass && collision.rigidbody.mass > minimumMass)
        {
            Destroy(toDestroy);
        }

        if (collision.gameObject.GetComponent<Tags>().IsTag("Interactive") && checkLight && collision.gameObject.GetComponent<Interactive>().lightEnergy > minimumLight)
        {
            Destroy(toDestroy);
        }
    }
}
