using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
