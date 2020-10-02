using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{  // Start is called before the first frame update
    public void showBunny()
    {
        GameObject SceneContent = GameObject.Find("SceneContent");
        GameObject bunny_data = (GameObject)Resources.Load("obj/bunny10k");
        GameObject bunny = (GameObject)Instantiate(bunny_data, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        bunny.transform.parent = SceneContent.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
