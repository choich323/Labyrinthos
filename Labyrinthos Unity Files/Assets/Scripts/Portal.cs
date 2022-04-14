using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool ischeck;
    public bool isGoal;

    void OnTriggerEnter(Collider other)                                         // 포탈에 플레이어가 접근하면
    {
        if(other.tag == "Player")
        {
            if (isGoal)                                                         // 이 포탈이 결승점이면
                SceneManager.LoadScene("PuzzleScene01");                        // 다음 스테이지로 이동

            other.transform.position = new Vector3(-4.5f, 0.11f, -7.46f);       // 최초 위치로 초기화
            ischeck = true;
        }
    }
}
