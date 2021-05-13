using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVisibility : MonoBehaviour
{

    public CanvasGroup[] uiToShow;
    public CanvasGroup[] uiToHide;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        // Hide all
        foreach (CanvasGroup ui in uiToHide)
        {
            ui.alpha = 0;
            ui.interactable = false;
        }

        // Show all
        foreach (CanvasGroup ui in uiToShow)
        {
            ui.alpha = 1;
            ui.interactable = true;
        }
    }

}
