using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarFire : MonoBehaviour
{
    public GameObject fire; // ����� ��

    public bool isfire; // ���� �پ�����
    public bool isblue; // ���� �Ķ��� ���ߴ���

    float time; // �ð�����

    void Update()
    {
        if(!isblue)
            FireOff();
    }

    void FireOff() // ���� �ð��� ������ ���� ��������
    {
        time += Time.deltaTime;
        if(time > 25) // ���� �ð��� ������
        {
            fire.SetActive(false); // ���� ������
            isfire = false;        // ���� ���� ���� �����ϰ�
            time = 0;              // �ð� �ʱ�ȭ
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire" && !isblue) // �Ķ� ���� �ƴѵ� ���� ��ó�� ������
        {
            fire.SetActive(true);   // �� ������Ʈ�� �Ѱ�
            isfire = true;          // ���� ���� ���� ����
        }
    }
}
