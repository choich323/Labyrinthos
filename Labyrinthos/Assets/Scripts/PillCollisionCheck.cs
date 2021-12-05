using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillCollisionCheck : MonoBehaviour
{
    private Rigidbody dishRigidbody;

    
    void Start()
    {
        dishRigidbody = GetComponent<Rigidbody>();

    }


   
   // 빨간 알약과 파란 알약의 충돌을 감지하여 Dish 위에 올라간 개수를 감지하는 함수
    void OnCollisionEnter(Collision collision) //충돌 시
    {
        if(collision.gameObject.tag == "RedPill")
        {
            EscapeManager.instance.level1_score += 10;
            Debug.Log("+ 10 score /" + EscapeManager.instance.level1_score);
        }
        if(collision.gameObject.tag == "BluePill")
        {
            EscapeManager.instance.level1_score ++;
            Debug.Log("+ 1 score /" + EscapeManager.instance.level1_score);
        }
    }
    void OnCollisionExit(Collision collision) //충돌 해제 시
    {
        if(collision.gameObject.tag == "RedPill")
        {
            EscapeManager.instance.level1_score -= 10;
            Debug.Log("- 10 score /" + EscapeManager.instance.level1_score);
        }
        if(collision.gameObject.tag == "BluePill")
        {
            EscapeManager.instance.level1_score --;
            Debug.Log("- 1 score /" + EscapeManager.instance.level1_score);
        }
    }
}
