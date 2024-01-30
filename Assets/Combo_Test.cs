using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo_Test : MonoBehaviour
{
    float Speed = 5;
    public int Combo_Counter = 0;

    public Rigidbody2D rb;
    Animator animator;

    public GameObject Object;

    public float Delay;
    public float Delay_Flag;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        // Collision();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            // Zキーで攻撃アニメーション
            animator.SetTrigger("Attack");
        }
    }
    void Collision()
    {
        // 攻撃アニメが再生されている場合
        if (animator.GetBool("Attack"))
        {
            Object.gameObject.SetActive(true);
            Delay_Flag = 1;
        }
        // 攻撃アニメが再生されていない場合
        else if (animator.GetBool("Attack") == false && Delay_Flag == 0) 
        {
            Object.gameObject.SetActive(false);
            Delay = 5;
        }
        if (Delay_Flag == 1)
        {
            Delay -= 0.01f;
            if(Delay <= 0)
            {
                Delay_Flag = 0;
                Delay = 5;
            }
        }
    }
    private void OnAnimatorMove()
    {
        animator.ResetTrigger("Attack");
    }
}
