using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public GameObject fire;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
            fire.SetActive(true);
        else if (other.tag == "Floor")
            fire.SetActive(false);
    }
}
