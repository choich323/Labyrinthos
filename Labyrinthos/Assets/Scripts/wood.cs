using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public GameObject fire; // ������ ��

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire") // �ҿ� ������ ���� �ٰ�
            fire.SetActive(true);
        else if (other.tag == "Floor")  // �ٴڿ� ����Ʈ���� ���� ����
            fire.SetActive(false);
    }
}
