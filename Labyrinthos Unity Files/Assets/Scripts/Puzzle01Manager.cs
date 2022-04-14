using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puzzle01Manager : MonoBehaviour
{
    public GameObject x_target; // N : 손에 든 정답 카드
    public GameObject o_target; // N : 벽의 정답 카드
    public GameObject mylight;  // N : 정답 시 켜지는 빛
    public GameObject bluefire; // 푸른 불꽃이 활성화되어있는지 확인하기 위함
    public GameObject answerBlock;  // 정답 블록
    public GameObject wrongBlock1;  // 오답 블록1
    public GameObject wrongBlock2;  // 오답 블록2

    public Transform nextMessage;
    public Transform preMessage;
    
    private Color currColor = new Color(1f, 1f, 1f, 0f);

    private bool flag = true;

    private void Start()
    {
        GameObject.Find("Question").transform.Find("PreMessage").GetComponent<Renderer>().material.color = currColor;  // N : 퍼즐 메세지 안보이게
        GameObject.Find("Question").transform.Find("NextMessage").GetComponent<Renderer>().material.color = currColor;  // N : 힌트 메세지 안보이게
        GameObject.Find("Question").transform.Find("NextMessage2").GetComponent<Renderer>().material.color = currColor; // N : 힌트 메세지2 안보이게
    }

    void Update()
    {
        LightUp();   
    }

    // N : 정답
    public void Correct()
    {
        if (flag == true)
        {
            x_target.SetActive(false);
            o_target.SetActive(true);
            MessageChange();
        }
        flag = false;
    }

    // N : 벽의 메세지 바꾸기
    public void MessageChange()
    {
        preMessage = GameObject.Find("Question").transform.Find("PreMessage");
        nextMessage = GameObject.Find("Question").transform.Find("NextMessage");
        currColor.a = 1f;
        StartCoroutine("fadeOut");
    }

    // N : 카드 빛나게
    public void LightUp()
    {
        if (GameObject.Find("Question").transform.Find("NextMessage2").GetComponent<Renderer>().material.color.a > 1)
        {
            mylight.GetComponent<Light>().intensity += 0.2f;
            mylight.GetComponent<Light>().range += 0.3f;
        }
        if (mylight.GetComponent<Light>().intensity > 15)
            SceneManager.LoadScene("flash back 1");
    }

    // N : 가까이 가면 문제가 보이게
    public void ShowPuzzle()
    {
        nextMessage = GameObject.Find("Question").transform.Find("PreMessage");
        currColor.a = 0f;
        answerBlock.SetActive(true);
        wrongBlock1.SetActive(true);
        wrongBlock2.SetActive(true);
        StartCoroutine("fadeIn",false);
    }

    IEnumerator fadeOut()
    {
        while (currColor.a > 0f)
        {
            currColor.a -= 0.1f;
            preMessage.GetComponent<Renderer>().material.color = currColor;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine("fadeIn",true);
    }
    
    IEnumerator fadeIn(bool isMore)
    {
        while (currColor.a < 1f)
        {
            currColor.a += 0.1f;
            nextMessage.GetComponent<Renderer>().material.color = currColor;
            yield return new WaitForSeconds(0.1f);
        }

        if (isMore == true) // fadeOut 함수가 실행되는 경우
        {
            nextMessage = GameObject.Find("Question").transform.Find("NextMessage2");
            currColor.a = 0f;
            StartCoroutine("fadeIn", false);
        }
    }
}
