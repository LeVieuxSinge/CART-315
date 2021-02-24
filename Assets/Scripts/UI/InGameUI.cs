using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{

    private GameInstance GameInstance;
    private CanvasGroup CanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        GameInstance = Globals.GetGameInstance();
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Hide ui if game not running
        if (!GameInstance.GameRunning)
        {
            CanvasGroup.alpha = 0;
        }
        else
        {
            CanvasGroup.alpha = 1;
        }
    }
}
