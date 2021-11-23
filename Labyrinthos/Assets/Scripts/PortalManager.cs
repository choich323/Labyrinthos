using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public Portal portal_1;
    public Portal portal_2;
    public Portal portal_3;
    public Portal portal_4;

    bool first, second, third, fourth;

    void Update()
    {
        StageClear();
    }

    void StageClear()
    {
        if (portal_1.ischeck)
        {
            first = true;
            portal_1.ischeck = false;
        }

        if (portal_2.ischeck)
        {
            if (first)
                second = true;
            portal_2.ischeck = false;
        }

        if (portal_3.ischeck)
        {
            if (!second)
            {
                first = false;
            }
            else
                third = true;
            portal_3.ischeck = false;
        }

        if (portal_4.ischeck)
        {
            if (!third)
            {
                portal_4.ischeck = false;
                first = false;
                second = false;
            }
            else
                SceneManager.LoadScene("PuzzleScene01");
        }
    }
}
