using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ariadne; // 아리아드네 에셋

    public GameObject cam;     // 카메라: 플레이어의 시점 변화를 알기 위함

    // 플레이어의 시점 변화에 따른 아리아드네의 위치(북, 동, 서, 남 순서)
    public GameObject targetN; 
    public GameObject targetE;
    public GameObject targetW;
    public GameObject targetS;

    public BoxCollider box;    // 플레이어의 물리 영역을 만드는 box

    Rigidbody rigid;
    Transform trans;

    float x, z; // 플레이어의 위치 저장을 위한 변수
    float time; // 아리아드네 시점 초기화 시간
    float y_ariadne; // 플레이어가 멈춰있을 때 아리아드네의 rotation.y 값
    float y_ariadneMove; // 플레이어가 움직일 때 아리아드네의 rotation.y 값

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


    // 플레이어의 시점 기준, 왼쪽에 아리아드네가 위치하도록 만듬
    // 플레이어의 시점이 바뀌면 아리아드네의 위치도 시점에 맞게 이동함
    // 플레이어가 움직이면 아리아드네도 플레이어의 정면 방향을 봄
    void AriadneLookAt()
    {
        time += Time.deltaTime;

        if (cam.transform.rotation.y >= -0.35f && cam.transform.rotation.y < 0.25)          // 플레이어가 북쪽 통로를 볼 때
            AriadneMove(targetN.transform.position, 130, 0);
        else if (cam.transform.rotation.y >= 0.45f && cam.transform.rotation.y < 0.8f)      // 플레이어가 동쪽 통로를 볼 때
            AriadneMove(targetE.transform.position, -130, 90);
        else if (cam.transform.rotation.y <= -0.55f && cam.transform.rotation.y > -0.8f)    // 플레이어가 서쪽 통로를 볼 때
            AriadneMove(targetW.transform.position, 50, -90);
        else if (cam.transform.rotation.y >= 0.95f || cam.transform.rotation.y <= -0.95f)   // 플레이어가 남쪽 통로를 볼 때
            AriadneMove(targetS.transform.position, -50, 180);

        if (time > 0.1f)                                                                 // 시간이 경과하면서
        {
            if (x == trans.position.x && z == trans.position.z)                         // 플레이어가 움직이지 않았으면
                ariadne.transform.rotation = Quaternion.Euler(0, y_ariadne, 0);         // 플레이어를 바라봄
            else                                                                        // 플레이어가 이동하는 경우 
            {
                ariadne.transform.rotation = Quaternion.Euler(0, y_ariadneMove, 0);     // 플레이어가 가는 방향을 바라봄
                x = trans.position.x; z = trans.position.z;                             // 이후 현재 위치를 저장
            }
            time = 0;                                                                   // 판정 시간 초기화
        }
    }

    void AriadneMove(Vector3 target, int y, int y_move)
    {
        ariadne.transform.position = Vector3.Lerp(ariadne.transform.position, target, 0.05f);   // 아리아드네 이동
        y_ariadne = y;                                                                          // 멈춰있는 플레이어의 시점에 맞게 아리아드네의 y축 조정
        y_ariadneMove = y_move;                                                                 // 움직이는 플레이어의 시점에 맞게 아리아드네의 y축 조정
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
