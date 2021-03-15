using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public float spawnDistance = 2.0f;
    public float destroyDistance = 10.0f;
    public GameObject[] platformsPrefab;
    private GameInstance GameInstance;
    private float lastSpawn = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameInstance.GameRunning)
        {
            // Get game distance
            float gameDistance = Mathf.Floor(GameInstance.GameDistance);

            // Is current distance higher than last recorded spawn
            if (gameDistance > lastSpawn)
            {
                // Is current distance far enough for new spawn distance
                if (gameDistance % spawnDistance == 0)
                {
                    // Spawn an object
                    Spawn();

                    // Set last spawn distance
                    lastSpawn = gameDistance;
                }
            }

            // Clear out of bounds platforms
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject item in platforms)
            {
                if (item.transform.position.x < (transform.position.x - destroyDistance))
                {
                    Destroy(item);
                }
            }
        }
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, platformsPrefab.Length);
        GameObject.Instantiate(platformsPrefab[randomIndex], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
