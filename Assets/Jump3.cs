using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump3 : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float jumpForce = 200f;

    public int MaxJumpCount = 2;
    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2Dコンポーネントの取得
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースを押したらジャンプさせる
        // MaxJumpCountの数だけジャンプできる
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < MaxJumpCount)
        {
            this.rigidbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Glound"))
        {
            jumpCount = 0;
        }
    }
}
