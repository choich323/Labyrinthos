using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public Puzzle01Manager puzzle01Manager;
    public GameObject blueFire; // 푸른 불꽃 활성화 여부

    void OnTriggerEnter(Collider coll) // N : 퍼즐 영역 안으로 들어가면 문제가 나타남
    {
        if (coll.tag == "Player" && blueFire.activeSelf) // 푸른 불꽃이 활성화되어있을 때 플레이어가 접근하면
        {
            puzzle01Manager.ShowPuzzle();
        }
    }
}
