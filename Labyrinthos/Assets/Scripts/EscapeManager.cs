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
    


    public int level1_answer = 42; //level1 정답 ( 4 redpills, 2 bluepills )
    public int level1_score = 0; //level1 현재 점수

    public int level2_clear = 0; // level2 정답 유무
    public int statue_col = 0;
    public int next_stage = 0;
    
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
        if(level1_score == level1_answer)
        {
            //Box.GetComponent<AudioSource>().Play();
            LockedDoor.SetActive(false);
            UnlockedDoor.SetActive(true);
            
        }
    }

    void Level2Clear()
    {
        if(level2_clear == 1)
        {
            

            Cup.SetActive(false);
            BloodCup.SetActive(true);
        }
    }

    void StatueChange()
    {
        if(statue_col == 1)
        {
            HorseStatue.SetActive(false);
            BloodStatue.SetActive(true);
        }
        
    }

    void NextStage()
    {
        if(next_stage == 1)
        {
            BloodStatue.SetActive(false);
            Portal.SetActive(true);

        }
    }

    
}
