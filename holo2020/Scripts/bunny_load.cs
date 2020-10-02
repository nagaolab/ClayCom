using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunny_load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject SceneContent = GameObject.Find("SceneContent");
        GameObject bunny_data = (GameObject)Resources.Load ("obj/bunny10k");
        GameObject bunny = (GameObject)Instantiate(bunny_data,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
        bunny.transform.parent = SceneContent.transform;
    }
}
