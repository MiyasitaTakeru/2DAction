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
        // �U���L�[�ōU�����肪�o��
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
        // �G�l�~�[�^�O�ɓ���������
        if (collision.gameObject.tag == "Enemy")
        {
            // Enemy.cs�̊֐����Ăяo��
            gameObject.GetComponent<Enemy>().Death();
            Debug.Log("�U��1");
        }
    }
    void OnEnable()
    {
        Debug.Log("�U���I");
    }


}


