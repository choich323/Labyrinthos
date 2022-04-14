using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    // �� ����� �Ϲ� �Ҳɰ� Ǫ�� �Ҳ�
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject blueFire1;
    public GameObject blueFire2;
    public GameObject blueFire3;
    public GameObject blueFire4;

    // ���� ������ ���� ��Ʈ���ϴ� 4���� Ʈ����
    public PillarFire pillarTrigger1;
    public PillarFire pillarTrigger2;
    public PillarFire pillarTrigger3;
    public PillarFire pillarTrigger4;

    void Update()
    {
        TurnBlue();
    }

    void TurnBlue() // 4���� �Ҳ��� Ȱ��ȭ�Ǹ� Ǫ�� �Ҳ����� �ٲٰ� �Ϲ� �Ҳ��� ������ �ʰ� �ȴ�.
    {
        if(pillarTrigger1.isfire && pillarTrigger2.isfire && pillarTrigger3.isfire && pillarTrigger4.isfire)
        {
            fire1.SetActive(false); fire2.SetActive(false); fire3.SetActive(false); fire4.SetActive(false); // �Ϲ� �Ҳ� off
            blueFire1.SetActive(true); blueFire2.SetActive(true); blueFire3.SetActive(true); blueFire4.SetActive(true);     // Ǫ�� �Ҳ� �ѱ�
            pillarTrigger1.isblue = true; pillarTrigger2.isblue = true; pillarTrigger3.isblue = true; pillarTrigger4.isblue = true; // �Ϲ� �Ҳ� ���� ����
        }
    }
}
