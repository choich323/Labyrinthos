using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public BoxCollider box; // 물리 영역 box collider
                            // trigger collider로 설정하면 안됩니다

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // 플레이어(카메라)와 충돌하면(플레이어가 물체를 잡으면)
            box.enabled = false;   // 물리 영역을 비활성화
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") // 플레이어가 물체를 놓으면
            box.enabled = true;   // 물리 영역을 활성화하여 벽이나 바닥에 부딪히도록
    }
}
