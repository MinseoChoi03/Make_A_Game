using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Vector3 m_Movement;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //FixedUpdate는 렌더링된 프레임에 맞춰 호출되는 것이 아닌, 물리 ㅣ스템이 충돌 및 상호작용을 계산하기 전 호출된다.
    void FixedUpdate() 
    {
        //사용자 입력 이동
        float horizontal = Input.GetAxis("Horizontal"); //수평
        float vertical = Input.GetAxis("Vertical"); //수직

        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();

        //플레이어의 입력 감지
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //캐릭터 회전
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    private void OnAnimatorMove()
    {
        //캐릭터 이동 및 회전 적용
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}