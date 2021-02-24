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
}
