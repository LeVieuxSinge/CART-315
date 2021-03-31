using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{

    public bool GameRunning = true;
    public bool PlayerDead = false;
    public bool LevelCompleted = false;
    public float GameSpeed = 1.0f;
    public float GameTime = 0.0f;
    public float GameDistance = 0.0f;
    public int GridCellSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update time
        if (GameRunning)
        {
            // Update game time
            if (Mathf.Floor(Time.time) > GameTime)
            {
                GameTime = Mathf.Floor(Time.timeSinceLevelLoad);
            }

            // Update game speed
            GameSpeed += 0.00001f;
        }

        // Stop game if player dead
        if (PlayerDead)
        {
            GameRunning = false;
        }
    }
}
