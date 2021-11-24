using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalOrb1;   // 포탈 오브 1~4
    public GameObject portalOrb2;
    public GameObject portalOrb3;
    public GameObject portalOrb4;

    public GameObject Goal;         // 결승점(포탈)

    public Portal portal_1;         // NEWS 방향의 포탈
    public Portal portal_2;
    public Portal portal_3;
    public Portal portal_4;

    bool first, second, third, fourth;  // 각 방향의 포탈 순서를 지켰는지 확인

    void Update()
    {
        StageClear();
        OrbOnOff();
    }

    void StageClear()
    {
        if (portal_1.ischeck)           // 첫번째 포탈을 통과한 경우
        {
            first = true;               
            portal_1.ischeck = false;
        }

        if (portal_2.ischeck)           // 두번째 포탈을 통과한 경우
        {
            if (first)                  // 첫번째를 통과한 기록이 있는 경우
                second = true;          // 두번째 통과를 승인
            portal_2.ischeck = false;
        }

        if (portal_3.ischeck)           // 세번째 포탈을 통과한 경우
        {
            if (!second)                // 순서에 맞게 두번째포탈을 통과한 기록이 없으면
            {
                first = false;          // 포탈 통과 기록 초기화
            }
            else                        // 순서에 맞게 포탈을 통과한 경우
                third = true;           // 세번째 포탈 통과를 승인
            portal_3.ischeck = false;
        }

        if (portal_4.ischeck)               // 네번째 포탈을 통과한 경우
        {
            if (!third)                     // 세번재 포탈을 통과한 기록이 없으면
            {
                first = false;              // 전체 포탈 통과기록 초기화
                second = false;
            }
            else                            // 순서에 맞게 통과한 경우
                fourth = true;              // 네번째 포탈 통과를 승인
            portal_4.ischeck = false;
        }
    }

    void OrbOnOff()
    {
        if (first)                          // 첫번째 포탈을 통과했으면
            portalOrb1.SetActive(true);     // 플레이어 주변의 오브를 하나 활성화
        else
            portalOrb1.SetActive(false);    // 통과 기록이 없으면 오브를 비활성화

        if (second)                         // 두번째 포탈까지 순서에 맞게 통과했으면
            portalOrb2.SetActive(true);     // 오브 활성화
        else
            portalOrb2.SetActive(false);    // 통과 기록이 없으면 오브를 비활성화

        if (third)                          // 세번째 포탈까지 순서에 맞게 통과했으면
            portalOrb3.SetActive(true);     // 오브 활성화
        else
            portalOrb3.SetActive(false);    // 통과 기록이 없으면 오브를 비활성화

        if (fourth)                         // 네번째 포탈까지 순서에 맞게 통과했으면
        {
            portalOrb4.SetActive(true);     // 오브 활성화
            Goal.SetActive(true);           // 결승점(포탈)을 활성화
        }
    }
}
