using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    // 네 기둥의 일반 불꽃과 푸른 불꽃
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject blueFire1;
    public GameObject blueFire2;
    public GameObject blueFire3;
    public GameObject blueFire4;

    // 불이 꺼지는 것을 컨트롤하는 4개의 트리거
    public PillarFire pillarTrigger1;
    public PillarFire pillarTrigger2;
    public PillarFire pillarTrigger3;
    public PillarFire pillarTrigger4;

    void Update()
    {
        TurnBlue();
    }

    void TurnBlue() // 4개의 불꽃이 활성화되면 푸른 불꽃으로 바꾸고 일반 불꽃이 나오지 않게 된다.
    {
        if(pillarTrigger1.isfire && pillarTrigger2.isfire && pillarTrigger3.isfire && pillarTrigger4.isfire)
        {
            fire1.SetActive(false); fire2.SetActive(false); fire3.SetActive(false); fire4.SetActive(false); // 일반 불꽃 off
            blueFire1.SetActive(true); blueFire2.SetActive(true); blueFire3.SetActive(true); blueFire4.SetActive(true);     // 푸른 불꽃 켜기
            pillarTrigger1.isblue = true; pillarTrigger2.isblue = true; pillarTrigger3.isblue = true; pillarTrigger4.isblue = true; // 일반 불꽃 켜짐 제한
        }
    }
}
