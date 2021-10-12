using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;


    bool m_IsPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어가 범위 안에 있을 때만
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycasHit;

            if(Physics.Raycast(ray, out raycasHit))
            {
                if (raycasHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
    // 캐릭터가 공격 범위에 있는지 확인
    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}
