using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;
    public float EnemyHP = 3;
    public float EnemyFlag = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // HPが0になった時
    public void Death()
    {
        EnemyFlag = 0;
        Debug.Log("ダメージ！");
    }
    // 攻撃が当たった時
    void Damage()
    {
        EnemyHP--;
        if(EnemyHP <= 0)
        {
            animator.SetTrigger("Hit");
            Death();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(EnemyFlag == 1)
        {
            Damage();
        }
    }
}
