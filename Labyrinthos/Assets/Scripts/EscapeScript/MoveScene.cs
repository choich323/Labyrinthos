using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    //포탈로 이동하여 씬 변경 (추후 씬 채워넣기)
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("");
        }
    }
}
