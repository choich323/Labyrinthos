using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashbackManager : MonoBehaviour
{
    public GameObject flashbackManger;
    public int flashbackNum;

    void Update()
    {
        if (!flashbackManger.activeSelf && flashbackNum == 1)
            SceneManager.LoadScene("EscapeScene");
        if (!flashbackManger.activeSelf && flashbackNum == 2)
            SceneManager.LoadScene("EndScene");
    }
}
