using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool ischeck;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = new Vector3(-4.5f, 0.11f, -7.46f);
            ischeck = true;
        }
    }
}
