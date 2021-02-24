using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPan : MonoBehaviour
{

    public float speedMultiplier = 0.01f;
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
        // Move object if game is running
        if (GameInstance.GameRunning)
        {
            GameInstance.GameDistance += GameInstance.GameSpeed * speedMultiplier;
            transform.position += new Vector3(GameInstance.GameSpeed * speedMultiplier, 0, 0);
        }
    }
}
