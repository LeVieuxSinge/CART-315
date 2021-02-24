using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenUI : MonoBehaviour
{
    private GameInstance GameInstance;
    private CanvasGroup CanvasGroup;
    private GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        CanvasGroup = GetComponent<CanvasGroup>();
        Score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Hide ui if game not running
        if (!GameInstance.GameRunning)
        {
            Score.GetComponent<Text>().text = GameInstance.GameTime.ToString();
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
        }
        else
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
        }
    }
}
