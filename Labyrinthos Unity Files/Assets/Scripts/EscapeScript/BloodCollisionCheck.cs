using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollisionCheck : MonoBehaviour
{
    public int KeyA = 0; // Level2 재료 1 유무
    public int KeyB = 0; // Level2 재료 2 유무
    public int KeyC = 0; // Level2 재료 3 유무
    public int else_thing = 0; // 이물질
    public int destroy = 0;

    // Update is called once per frame
    void Update()
    {
        ClearCheck();
    }

    void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "KeyA")
        {
            KeyA = 1;
        }
        else if(collision.gameObject.tag == "KeyB")
        {
            KeyB++;
        }
        else if(collision.gameObject.tag == "RedPill")
        {
            KeyC++;
        }
        else
        {
            else_thing ++;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "KeyA")
        {
            KeyA = 0;
        }
        else if(collision.gameObject.tag == "KeyB")
        {
            KeyB--;
        }
        else if(collision.gameObject.tag == "RedPill")
        {
            KeyC--;
        }
        else
        {
            else_thing --;
        }
    }

    void OnTriggerStay (Collider collision)
    {
        if(EscapeManager.instance.level2_clear == 1 && destroy == 0)
        {
            if (collision.gameObject.tag != "Statue" && collision.gameObject.tag != "BloodStatue") //statue가 없으면 게임이 진행이 안됨
            {
                Destroy(collision.gameObject);
                destroy = 1;
            }
        }
    }

    void ClearCheck()
    {
        // 혹시 모를 버그 및 난이도 완화를 위해서 이물질 상관없이 재료만 다 들어가면 클리어로 판정
        if (KeyA == 1 && KeyB >= 1 && KeyC >= 1)
        {
            EscapeManager.instance.level2_clear = 1;
        }
    }
}
