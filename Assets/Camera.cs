using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camel : MonoBehaviour
{
    //Player player;
    GameObject PlayerObj;
    Transform PlayerTransform;
    // カメラ追従やる

    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        //player = PlayerObj.GetComponent<Transform>();
        PlayerTransform = PlayerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
