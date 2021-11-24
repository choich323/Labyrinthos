using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool ischeck;
    public bool isGoal;

    void OnTriggerEnter(Collider other)                                         // ��Ż�� �÷��̾ �����ϸ�
    {
        if(other.tag == "Player")
        {
            if (isGoal)                                                         // �� ��Ż�� ������̸�
                SceneManager.LoadScene("PuzzleScene01");                        // ���� ���������� �̵�

            other.transform.position = new Vector3(-4.5f, 0.11f, -7.46f);       // ���� ��ġ�� �ʱ�ȭ
            ischeck = true;
        }
    }
}
