using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeManager : MonoBehaviour
{
    public static EscapeManager instance;
    
    public GameObject LockedDoor;
    public GameObject UnlockedDoor;
    

    public GameObject HorseStatue;
    public GameObject BloodStatue;
    public GameObject Cup;
    public GameObject BloodCup;
    public GameObject Portal;
    public GameObject BloodEffect;
    


    public int level1_answer = 42; //level1 정답 ( 4 redpills, 2 bluepills )
    public int level1_score = 0; //level1 현재 점수

    public int level2_clear = 0; // level2 정답 유무
    public int statue_col = 0; // Blood Cup 에 Horse Statue를 넣었는가?
    public int next_stage = 0; // Next Stage로 가기 위해 Blood Statue를 칼로 베었는가?
    public int On_table = 0; // Blood Statue가 제물대 위에 있는가?
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Too much Game Manager");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }
    void Update()
    { 
        Level1Clear();
        Level2Clear();
        StatueChange();
        NextStage();
    }


    void Level1Clear()
    {
        //잠긴 문 열기
        if(level1_score == level1_answer)
        {
            
            LockedDoor.SetActive(false);
            UnlockedDoor.SetActive(true);
            
        }
    }

    void Level2Clear()
    {
        // 빈 그릇이 피의 그릇으로 변함
        if(level2_clear == 1)
        {
            Cup.SetActive(false);
            BloodCup.SetActive(true);
        }
    }

    void StatueChange()
    {
        // 일반 Horse Statue가 Blood Statue로 변함
        if(statue_col == 1)
        {
            HorseStatue.SetActive(false);
            BloodStatue.SetActive(true);
        }
        
    }

    void NextStage()
    {
        // 제물로 바친 Blood Statue가 사라지고 포탈이 열림
        if(next_stage == 1)
        {
            BloodStatue.SetActive(false);
            BloodEffect.SetActive(true);
            Portal.SetActive(true);

        }
    }

    
}
