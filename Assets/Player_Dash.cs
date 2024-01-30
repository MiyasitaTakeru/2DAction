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

    //��_�Ԃ̋���������
    private float Lerp_Point;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //��_�Ԃ̋�������(�X�s�[�h�����Ɏg��)
        Lerp_Point = Vector3.Distance(Lerp_Start.position, Lerp_End.position);
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̈ʒu
        float present_Location = (Time.time * Leap_Speed) / Lerp_Point;
        // �I�u�W�F�N�g�̈ړ�
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
