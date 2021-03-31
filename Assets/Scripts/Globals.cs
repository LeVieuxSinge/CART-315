using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static GameInstance GetGameInstance()
    {
        GameObject GameInstanceObject = GameObject.FindGameObjectWithTag("GameInstance");
        GameInstance GameInstance = GameInstanceObject.GetComponent<GameInstance>();
        return GameInstance;
    }

    public static GameObject GetPlayer()
    {
        return FindObjectByTag("Player");
    }

    public static GameObject FindObjectByTag(string tag)
    {
        GameObject OutputObject = null;
        Tags[] GameTags = GameObject.FindObjectsOfType<Tags>();
        foreach (Tags item in GameTags)
        {
            if (item.IsTag(tag))
            {
                OutputObject = item.gameObject;
                break;
            }
        }
        return OutputObject;
    }

    public static GameObject[] FindObjectsByTag(string tag)
    {
        GameObject[] OutputObject = null;
        Tags[] GameTags = GameObject.FindObjectsOfType<Tags>();
        foreach (Tags item in GameTags)
        {
            if (item.IsTag(tag))
            {
                OutputObject.SetValue(item.gameObject, OutputObject.Length);
            }
        }
        return OutputObject;
    }
}
