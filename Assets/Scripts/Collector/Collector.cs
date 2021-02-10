using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Collector : MonoBehaviour
{

    public Texture2D[] foods;

    public bool require1_done = false;
    public bool require2_done = false;
    public bool require3_done = false;

    GameObject require1;
    GameObject require2;
    GameObject require3;

    Texture2D require1_texture;
    Texture2D require2_texture;
    Texture2D require3_texture;

    // Start is called before the first frame update
    void Start()
    {

        require1 = GameObject.Find("Require1");
        require2 = GameObject.Find("Require2");
        require3 = GameObject.Find("Require3");

        require1_texture = foods[Random.Range(0, foods.Length - 1)];
        require2_texture = foods[Random.Range(0, foods.Length - 1)];
        require3_texture = foods[Random.Range(0, foods.Length - 1)];

        require1.GetComponent<Renderer>().material.SetTexture("_MainTex", require1_texture);
        require2.GetComponent<Renderer>().material.SetTexture("_MainTex", require2_texture);
        require3.GetComponent<Renderer>().material.SetTexture("_MainTex", require3_texture);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tags>().IsTag(require1_texture.name))
        {
            require1_done = true;
            GameObject.Destroy(require1);
            GameObject.Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<Tags>().IsTag(require2_texture.name))
        {
            require2_done = true;
            GameObject.Destroy(require2);
            GameObject.Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<Tags>().IsTag(require3_texture.name))
        {
            require3_done = true;
            GameObject.Destroy(require3);
            GameObject.Destroy(other.gameObject);
        }
    }

}
