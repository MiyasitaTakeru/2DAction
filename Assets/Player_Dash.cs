using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    Animator animator;

    //Lerp
    public Transform Lerp_Start;
    public Transform Lerp_End;
    public float Leap_Speed;

    //二点間の距離を入れる
    private float Lerp_Point;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //二点間の距離を代入(スピード調整に使う)
        Lerp_Point = Vector3.Distance(Lerp_Start.position, Lerp_End.position);
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の位置
        float present_Location = (Time.time * Leap_Speed) / Lerp_Point;
        // オブジェクトの移動
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("Dash", true);
        }
        if (animator.GetBool("Dash"))
        {
            transform.position = Vector2.Lerp(Lerp_Start.position, Lerp_End.position, present_Location);
        }
    }
    private void OnAnimatorMove()
    {
        animator.ResetTrigger("Dash");
    }
}
