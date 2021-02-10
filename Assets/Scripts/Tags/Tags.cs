using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tags : MonoBehaviour
{

    public string[] tags;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTag(string tag)
    {
        if (tags.Contains(tag))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
