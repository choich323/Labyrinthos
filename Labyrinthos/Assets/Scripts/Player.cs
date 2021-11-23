using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ariadne; // �Ƹ��Ƶ�� ����

    public GameObject cam;     // ī�޶�: �÷��̾��� ���� ��ȭ�� �˱� ����

    // �÷��̾��� ���� ��ȭ�� ���� �Ƹ��Ƶ���� ��ġ(��, ��, ��, �� ����)
    public GameObject targetN; 
    public GameObject targetE;
    public GameObject targetW;
    public GameObject targetS;

    public BoxCollider box;    // �÷��̾��� ���� ������ ����� box

    Rigidbody rigid;
    Transform trans;

    float x, z; // �÷��̾��� ��ġ ������ ���� ����
    float time; // �Ƹ��Ƶ�� ���� �ʱ�ȭ �ð�
    float y_ariadne; // �÷��̾ �������� �� �Ƹ��Ƶ���� rotation.y ��
    float y_ariadneMove; // �÷��̾ ������ �� �Ƹ��Ƶ���� rotation.y ��

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


    // �÷��̾��� ���� ����, ���ʿ� �Ƹ��Ƶ�װ� ��ġ�ϵ��� ����
    // �÷��̾��� ������ �ٲ�� �Ƹ��Ƶ���� ��ġ�� ������ �°� �̵���
    // �÷��̾ �����̸� �Ƹ��Ƶ�׵� �÷��̾��� ���� ������ ��
    void AriadneLookAt()
    {
        time += Time.deltaTime;

        if (cam.transform.rotation.y >= -0.35f && cam.transform.rotation.y < 0.25)          // �÷��̾ ���� ��θ� �� ��
            AriadneMove(targetN.transform.position, 130, 0);
        else if (cam.transform.rotation.y >= 0.45f && cam.transform.rotation.y < 0.8f)      // �÷��̾ ���� ��θ� �� ��
            AriadneMove(targetE.transform.position, -130, 90);
        else if (cam.transform.rotation.y <= -0.45f && cam.transform.rotation.y > -0.8f)    // �÷��̾ ���� ��θ� �� ��
            AriadneMove(targetW.transform.position, 50, -90);
        else if (cam.transform.rotation.y >= 0.95f || cam.transform.rotation.y <= -0.95f)   // �÷��̾ ���� ��θ� �� ��
            AriadneMove(targetS.transform.position, -50, 180);

        if (time > 0.1f)                                                                 // �ð��� ����ϸ鼭
        {
            if (x == trans.position.x && z == trans.position.z)                         // �÷��̾ �������� �ʾ�����
                ariadne.transform.rotation = Quaternion.Euler(0, y_ariadne, 0);         // �÷��̾ �ٶ�
            else                                                                        // �÷��̾ �̵��ϴ� ��� 
            {
                ariadne.transform.rotation = Quaternion.Euler(0, y_ariadneMove, 0);     // �÷��̾ ���� ������ �ٶ�
                x = trans.position.x; z = trans.position.z;                             // ���� ���� ��ġ�� ����
            }
            time = 0;                                                                   // ���� �ð� �ʱ�ȭ
        }
    }

    void AriadneMove(Vector3 target, int y, int y_move)
    {
        ariadne.transform.position = Vector3.Lerp(ariadne.transform.position, target, 0.05f);   // �Ƹ��Ƶ�� �̵�
        y_ariadne = y;                                                                          // �����ִ� �÷��̾��� ������ �°� �Ƹ��Ƶ���� y�� ����
        y_ariadneMove = y_move;                                                                 // �����̴� �÷��̾��� ������ �°� �Ƹ��Ƶ���� y�� ����
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
