using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerInteraction : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        //칼로 Blood Statue를 베었을 경우 and 제물대 위에 있는 경우 , 트리거 값 변경 + 베는 소리 출력
        if(collider.gameObject.tag == "BloodStatue" && EscapeManager.instance.On_table == 1)
        {
            EscapeManager.instance.next_stage = 1;
            GetComponent<AudioSource>().Play();
        }
    }
}
