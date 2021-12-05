using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Statue")
        {
            EscapeManager.instance.statue_col = 1;
        }
    }
}
