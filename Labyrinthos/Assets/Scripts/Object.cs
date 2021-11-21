using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public BoxCollider box; // ���� ���� box collider
                            // trigger collider�� �����ϸ� �ȵ˴ϴ�

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // �÷��̾�(ī�޶�)�� �浹�ϸ�(�÷��̾ ��ü�� ������)
            box.enabled = false;   // ���� ������ ��Ȱ��ȭ
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") // �÷��̾ ��ü�� ������
            box.enabled = true;   // ���� ������ Ȱ��ȭ�Ͽ� ���̳� �ٴڿ� �ε�������
    }
}
