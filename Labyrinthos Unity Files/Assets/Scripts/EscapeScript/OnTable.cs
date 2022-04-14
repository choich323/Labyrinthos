using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTable : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "BloodStatue")
        {
            EscapeManager.instance.On_table = 1;
        }
    }
}
