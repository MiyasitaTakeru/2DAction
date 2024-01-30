using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision_Attack : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;

    
    public float Collision_Delay_Flag;
    public float Collision_Delay;
    public float Collision_Flag;
    public float Collision_Time;

    public GameObject Object;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 攻撃キーで攻撃判定が出る
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (animator.GetBool("Attack"))
            {
                Object.gameObject.SetActive(true);
            }
            else if (animator.GetBool("Attack") == false)
            {
                Object.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // エネミータグに当たった時
        if (collision.gameObject.tag == "Enemy")
        {
            // Enemy.csの関数を呼び出す
            gameObject.GetComponent<Enemy>().Death();
            Debug.Log("攻撃1");
        }
    }
    void OnEnable()
    {
        Debug.Log("攻撃！");
    }


}


