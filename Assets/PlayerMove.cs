using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // スピード
    public float Speed;

    // 2
    public float jumpForce = 200f;
    public int MaxJumpCount = 2;
    public int jumpCount = 0;

    // 接地チェック
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
        
        // 移動
        Move2();
        Jump();
    }

    // 移動
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
        // 接地
        isGround = ground.IsGround();

        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        float verticalKey = Input.GetAxis("Vertical");

        //// ジャンプ
        //if (isGround)
        //{
        //    if (verticalKey > 0)
        //    {
        //        ySpeed = jumpSpeed;
        //        //ジャンプした位置を記録
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
        //    //上ボタンを押されている、かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
        //    if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y)
        //    {
        //        ySpeed = jumpSpeed;
        //    }
        //    else
        //    {
        //        isJump = false;
        //    }
        //}

        // 移動
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
        // スペースを押したらジャンプ
        // MaxJumpCountの数だけジャンプできる
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < MaxJumpCount) 
        {
            this.rb.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
        // 接地したら
        if (isGround)
        {
            // カウントリセット
            jumpCount = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("敵と接触した！");
            // プレイヤーの位置を後ろに飛ばす
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
