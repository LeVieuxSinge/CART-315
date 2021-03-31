using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassTrigger : MonoBehaviour
{

    public GameObject toDestroy;
    public float minimumMass = 1;

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
        if (GameInstance.GameRunning)
        {
            if (collision.gameObject.GetComponent<Tags>().IsTag("Interactive") && collision.rigidbody.mass > minimumMass)
            {
                Destroy(toDestroy);
            }
        }
    }
}
