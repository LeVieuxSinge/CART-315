using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{

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
        if (GameInstance.GameRunning)
        {
            if (other.gameObject.tag == "Player")
            {
                GameInstance.LevelCompleted = true;
            }
        }
    }
}
