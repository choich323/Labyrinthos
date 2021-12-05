using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        //Blood Cup 에 Horse Statue를 넣었을 경우
        if(col.gameObject.tag == "Statue")
        {
            EscapeManager.instance.statue_col = 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        //첨벙거리는 소리 
        if(GetComponent<AudioSource>().isPlaying) 
        {
            return;
        }
        else 
        {
            GetComponent<AudioSource>().Play();
        }
            
    }
}
