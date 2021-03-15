using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public float distance = 10.0f;
    public float spawnRate = 0.0001f;
    public float destroyDistance = 10.0f;
    public GameObject[] objectsPrefab;

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
        if (GameInstance.GameRunning)
        {
            // Chances of spawning an object
            if (Random.Range(0.000f, 1.000f) < spawnRate)
            {
                // Spawn object
                Spawn();
            }

            // Clear out of bounds platforms
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
            foreach (GameObject item in objects)
            {
                if (Vector3.Distance(item.transform.position, transform.position) > destroyDistance)
                {
                    Destroy(item);
                }
            }
        }
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, objectsPrefab.Length);
        float randomPos = Random.Range(-distance, distance);
        GameObject.Instantiate(objectsPrefab[randomIndex], new Vector3(transform.position.x + randomPos, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
