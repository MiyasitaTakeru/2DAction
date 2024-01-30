using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camel : MonoBehaviour
{
    //Player player;
    GameObject PlayerObj;
    Transform PlayerTransform;
    // ÉJÉÅÉâí«è]Ç‚ÇÈ

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
