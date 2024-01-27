using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpGameManager : MonoBehaviour
{
    public int nowStage;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Money").Length < 1)
        {
            nowStage += 1;
            Time.timeScale = 0;
            PlayerPrefs.SetInt("levelReached", nowStage);
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
