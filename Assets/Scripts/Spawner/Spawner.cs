using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int amount = 100;
    public int rangeX = 10;
    public int rangeZ = 10;
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            int randomPosX = Random.Range(-rangeX, rangeX);
            int randomPosZ = Random.Range(-rangeZ, rangeZ);
            GameObject.Instantiate(prefabs[randomIndex], new Vector3(transform.position.x + randomPosX, transform.position.y, transform.position.z + randomPosZ), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
