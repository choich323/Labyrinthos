using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalOrb1;   // ��Ż ���� 1~4
    public GameObject portalOrb2;
    public GameObject portalOrb3;
    public GameObject portalOrb4;

    public GameObject Goal;         // �����(��Ż)

    public Portal portal_1;         // NEWS ������ ��Ż
    public Portal portal_2;
    public Portal portal_3;
    public Portal portal_4;

    bool first, second, third, fourth;  // �� ������ ��Ż ������ ���״��� Ȯ��

    void Update()
    {
        StageClear();
        OrbOnOff();
    }

    void StageClear()
    {
        if (portal_1.ischeck)           // ù��° ��Ż�� ����� ���
        {
            first = true;               
            portal_1.ischeck = false;
        }

        if (portal_2.ischeck)           // �ι�° ��Ż�� ����� ���
        {
            if (first)                  // ù��°�� ����� ����� �ִ� ���
                second = true;          // �ι�° ����� ����
            portal_2.ischeck = false;
        }

        if (portal_3.ischeck)           // ����° ��Ż�� ����� ���
        {
            if (!second)                // ������ �°� �ι�°��Ż�� ����� ����� ������
            {
                first = false;          // ��Ż ��� ��� �ʱ�ȭ
            }
            else                        // ������ �°� ��Ż�� ����� ���
                third = true;           // ����° ��Ż ����� ����
            portal_3.ischeck = false;
        }

        if (portal_4.ischeck)               // �׹�° ��Ż�� ����� ���
        {
            if (!third)                     // ������ ��Ż�� ����� ����� ������
            {
                first = false;              // ��ü ��Ż ������ �ʱ�ȭ
                second = false;
            }
            else                            // ������ �°� ����� ���
                fourth = true;              // �׹�° ��Ż ����� ����
            portal_4.ischeck = false;
        }
    }

    void OrbOnOff()
    {
        if (first)                          // ù��° ��Ż�� ���������
            portalOrb1.SetActive(true);     // �÷��̾� �ֺ��� ���긦 �ϳ� Ȱ��ȭ
        else
            portalOrb1.SetActive(false);    // ��� ����� ������ ���긦 ��Ȱ��ȭ

        if (second)                         // �ι�° ��Ż���� ������ �°� ���������
            portalOrb2.SetActive(true);     // ���� Ȱ��ȭ
        else
            portalOrb2.SetActive(false);    // ��� ����� ������ ���긦 ��Ȱ��ȭ

        if (third)                          // ����° ��Ż���� ������ �°� ���������
            portalOrb3.SetActive(true);     // ���� Ȱ��ȭ
        else
            portalOrb3.SetActive(false);    // ��� ����� ������ ���긦 ��Ȱ��ȭ

        if (fourth)                         // �׹�° ��Ż���� ������ �°� ���������
        {
            portalOrb4.SetActive(true);     // ���� Ȱ��ȭ
            Goal.SetActive(true);           // �����(��Ż)�� Ȱ��ȭ
        }
    }
}
