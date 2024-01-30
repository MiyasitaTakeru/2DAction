using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �X�s�[�h
    public float Speed;

    // 2
    public float jumpForce = 200f;
    public int MaxJumpCount = 2;
    public int jumpCount = 0;

    // �ڒn�`�F�b�N
    public Ground_Check ground;

    public Rigidbody2D rb;
    Animator animator;
    private bool isGround = false;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        // �ړ�
        Move2();
        Jump();
    }

    // �ړ�
    //void Move()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    if (x > 0)
    //    {
    //        transform.localScale = new Vector2(1, 1);
    //    }
    //    if (x < 0)
    //    {
    //        transform.localScale = new Vector2(-1, 1);
    //    }


    //    animator.SetFloat("Speed", Mathf.Abs(x));
    //    rb.velocity = new Vector2(x * Speed, rb.velocity.y);
    //}
    void Move2()
    {
        // �ڒn
        isGround = ground.IsGround();

        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        float verticalKey = Input.GetAxis("Vertical");

        //// �W�����v
        //if (isGround)
        //{
        //    if (verticalKey > 0)
        //    {
        //        ySpeed = jumpSpeed;
        //        //�W�����v�����ʒu���L�^
        //        jumpPos = transform.position.y;
        //        isJump = true;
        //    }
        //    else
        //    {
        //        isJump = false;
        //    }
        //}
        //else if (isJump)
        //{
        //    //��{�^����������Ă���A���A���݂̍������W�����v�����ʒu���玩���̌��߂��ʒu��艺�Ȃ�W�����v���p������
        //    if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y)
        //    {
        //        ySpeed = jumpSpeed;
        //    }
        //    else
        //    {
        //        isJump = false;
        //    }
        //}

        // �ړ�
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Run", true);
            xSpeed = Speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Run", true);
            xSpeed = -Speed;
        }
        else
        {
            animator.SetBool("Run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    void Jump()
    {
        // �X�y�[�X����������W�����v
        // MaxJumpCount�̐������W�����v�ł���
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < MaxJumpCount) 
        {
            this.rb.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
        // �ڒn������
        if (isGround)
        {
            // �J�E���g���Z�b�g
            jumpCount = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�G�ƐڐG�����I");
            // �v���C���[�̈ʒu�����ɔ�΂�
            //float s = 100f * Time.deltaTime;
            //transform.Translate(Vector3.up * s);
            //if (transform.localScale.x >= 0)
            //{
            //    transform.Translate(Vector3.left * s);
            //}
            //else
            //{
            //    transform.Translate(Vector3.right * s);
            //}
        }
    }

}
