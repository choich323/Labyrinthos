using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarFire : MonoBehaviour
{
    public GameObject fire; // 기둥의 불

    public bool isfire; // 불이 붙었는지
    public bool isblue; // 불이 파랗게 변했는지

    float time; // 시간제한

    void Update()
    {
        if(!isblue && isfire)
            FireOff();
    }

    void FireOff() // 일정 시간이 지나면 불이 꺼지도록
    {
        time += Time.deltaTime;
        if(time > 20) // 일정 시간이 지나면
        {
            fire.SetActive(false); // 불이 꺼지고
            isfire = false;        // 불이 꺼진 것을 저장하고
            time = 0;              // 시간 초기화
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire" && !isblue) // 파란 불이 아닌데 불이 근처에 있으면
        {
            fire.SetActive(true);   // 불 오브젝트를 켜고
            isfire = true;          // 불이 붙은 것을 저장
        }
    }
}
