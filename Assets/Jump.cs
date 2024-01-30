using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    enum Status
    {
        GROUND = 1,
        UP = 2,
        DOWN = 3,
    }

    Status playerStatus = Status.GROUND; // �v���C���[�̏��
    Rigidbody2D rb;

    public float firstSpeed = 16.0f; // ����
    public float gravity = 120.0f; // �d��
    public float jumpLowerLimit = 0.03f; // �W�����v���Ԃ̉���

    float timer = 0f; // �o�ߎ���
    bool jumpKey = false; // �W�����v�L�[
    bool keyLook = false; // �L�[���͂��󂯕t���Ȃ�

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �L�[���͎擾
        if (Input.GetKey(KeyCode.X))
        {
            jumpKey = !keyLook;
        }
        else
        {
            jumpKey = false;
            keyLook = false;
        }
    }
    void FixedUpdate()
    {
        Vector2 newvec = Vector2.zero;

        switch (playerStatus)
        {
            // �ڒn��
            case Status.GROUND:
                if (jumpKey)
                {
                    playerStatus = Status.UP;
                }
                break;

            // �㏸��
            case Status.UP:
                timer += Time.deltaTime;

                if (jumpKey || jumpLowerLimit > timer)
                {
                    newvec.y = firstSpeed;
                    newvec.y -= (gravity * Mathf.Pow(timer, 2));
                }

                else
                {
                    timer += Time.deltaTime; // �����𑁂߂�
                    newvec.y = firstSpeed;
                    newvec.y -= (gravity * Mathf.Pow(timer, 2));
                }

                if (0f > newvec.y)
                {
                    playerStatus = Status.DOWN;
                    newvec.y = 0f;
                    timer = 0.1f;
                }
                break;

            // ������
            case Status.DOWN:
                timer += Time.deltaTime;

                newvec.y = 0f;
                newvec.y = -(gravity * Mathf.Pow(timer, 2));
                break;

            default:
                break;
        }

        rb.velocity = newvec;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (playerStatus == Status.DOWN &&
            collision.gameObject.CompareTag("Ground"))
        {
            playerStatus = Status.GROUND;
            timer = 0f;
            keyLook = true; // �L�[��������b�N����
        }
    }
}
