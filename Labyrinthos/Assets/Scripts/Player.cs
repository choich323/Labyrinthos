using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ariadne; // 아리아드네 에셋

    public BoxCollider box; // 플레이어의 물리 영역을 만드는 box
    Rigidbody rigid;
    Transform trans;
    float x, z; // 플레이어의 위치 저장을 위한 변수
    float time; // 아리아드네 시점 초기화 시간

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        x = trans.position.x; z = trans.position.z; // 최초 플레이어의 위치 저장
    }

    void FixedUpdate()
    {
        AriadneLookAt();
    }

    void AriadneLookAt()
    {
        time += Time.deltaTime;

        if (time > 0.1f)                                                    // 시간이 경과하면서
        {
            if (x == trans.position.x && z == trans.position.z)             // 플레이어가 움직이지 않았으면
                ariadne.transform.rotation = Quaternion.Euler(0, 130, 0);   // 플레이어를 바라봄
            else                                                            // 플레이어가 이동하는 경우 
            {
                ariadne.transform.rotation = Quaternion.identity;           // 플레이어가 가는 방향을 바라봄
                x = trans.position.x; z = trans.position.z;                 // 이후 현재 위치를 저장
            }
            time = 0;                                                       // 시간 초기화
        }
    }

    void OnTriggerEnter(Collider other) // 벽 충돌시
    {
        if (other.tag == "Wall") // 벽에 충돌하면
        {
            box.enabled = true; // box collider를 활성화
        }
    }

    void OnTriggerStay(Collider other) // 벽에 비비다 보면 벽을 통과하는 상황 방지
    {
        if (other.tag == "Wall" && !box.enabled) // 벽에 닿은 상태인데 플레이어의 물리 영역이 활성화 되어 있지 않으면
            box.enabled = true;                  // 플레이어의 물리 영역을 활성화
    }

    void OnTriggerExit(Collider other)  // 벽에서 떨어지면
    {
        if (other.tag == "Wall")
        {
            box.enabled = false;                    // 물리 영역을 비활성화
            rigid.angularVelocity = Vector3.zero;   // 벽에 부딪히면서 생기는 각속도 제거
            rigid.velocity = Vector3.zero;          // 속도 제거
        }
    }
}
