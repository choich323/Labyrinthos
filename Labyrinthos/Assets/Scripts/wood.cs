using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public GameObject fire; // 나무의 불

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire") // 불에 닿으면 불이 붙고
            fire.SetActive(true);
        else if (other.tag == "Floor")  // 바닥에 떨어트리면 불이 꺼짐
            fire.SetActive(false);
    }
}
