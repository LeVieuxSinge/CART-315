using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{

    public GameObject[] toDestroy;
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
        if (GameInstance.GameRunning)
        {
            if (collision.gameObject.GetComponent<Tags>().IsTag("Interactive") && collision.gameObject.TryGetComponent(out Absorber absorber))
            {
                if (collision.gameObject.GetComponent<Absorber>().energy > minimumLight)
                {
                    foreach (GameObject item in toDestroy)
                    {
                        Destroy(item);
                    }
                }
            }
        }
    }
}
