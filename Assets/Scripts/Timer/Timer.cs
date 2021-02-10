using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public double timer = 60;
    double currentTimer;

    Slider slider;
    GameObject collector;
    Collector trigger;

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        collector = GameObject.Find("Collector/Trigger");
        trigger = collector.GetComponent<Collector>();
        currentTimer = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTimer -= 0.02;
        slider.value = map((float)currentTimer, 0, (float)timer, 0, 1);

        if (currentTimer <= 0)
        {
            SceneManager.LoadScene("Level_1");
        }

        if (trigger.require1_done && trigger.require2_done && trigger.require3_done)
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
