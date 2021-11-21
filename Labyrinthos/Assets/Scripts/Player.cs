using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ariadne; // �Ƹ��Ƶ�� ����

    public BoxCollider box; // �÷��̾��� ���� ������ ����� box
    Rigidbody rigid;
    Transform trans;
    float x, z; // �÷��̾��� ��ġ ������ ���� ����
    float time; // �Ƹ��Ƶ�� ���� �ʱ�ȭ �ð�

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        x = trans.position.x; z = trans.position.z; // ���� �÷��̾��� ��ġ ����
    }

    void FixedUpdate()
    {
        AriadneLookAt();
    }

    void AriadneLookAt()
    {
        time += Time.deltaTime;

        if (time > 0.1f)                                                    // �ð��� ����ϸ鼭
        {
            if (x == trans.position.x && z == trans.position.z)             // �÷��̾ �������� �ʾ�����
                ariadne.transform.rotation = Quaternion.Euler(0, 130, 0);   // �÷��̾ �ٶ�
            else                                                            // �÷��̾ �̵��ϴ� ��� 
            {
                ariadne.transform.rotation = Quaternion.identity;           // �÷��̾ ���� ������ �ٶ�
                x = trans.position.x; z = trans.position.z;                 // ���� ���� ��ġ�� ����
            }
            time = 0;                                                       // �ð� �ʱ�ȭ
        }
    }

    void OnTriggerEnter(Collider other) // �� �浹��
    {
        if (other.tag == "Wall") // ���� �浹�ϸ�
        {
            box.enabled = true; // box collider�� Ȱ��ȭ
        }
    }

    void OnTriggerStay(Collider other) // ���� ���� ���� ���� ����ϴ� ��Ȳ ����
    {
        if (other.tag == "Wall" && !box.enabled) // ���� ���� �����ε� �÷��̾��� ���� ������ Ȱ��ȭ �Ǿ� ���� ������
            box.enabled = true;                  // �÷��̾��� ���� ������ Ȱ��ȭ
    }

    void OnTriggerExit(Collider other)  // ������ ��������
    {
        if (other.tag == "Wall")
        {
            box.enabled = false;                    // ���� ������ ��Ȱ��ȭ
            rigid.angularVelocity = Vector3.zero;   // ���� �ε����鼭 ����� ���ӵ� ����
            rigid.velocity = Vector3.zero;          // �ӵ� ����
        }
    }
}
