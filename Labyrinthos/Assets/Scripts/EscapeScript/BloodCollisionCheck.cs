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

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            Destroy(collision.gameObject);
            destroy = 1;

        }
    }

    void ClearCheck()
    {
        if(KeyA == 1 && KeyB >= 1 && KeyC >= 1)
        {
            EscapeManager.instance.level2_clear = 1;
        }
    }


}
