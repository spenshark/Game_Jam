using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tmpGameManager : MonoBehaviour
{
    public int nowStage;

    private void Start()
    {
        nowStage = PlayerPrefs.GetInt("levelReached");
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Money").Length < 1)
        {
            nowStage += 1;
            Time.timeScale = 0;
            PlayerPrefs.SetInt("levelReached", nowStage);
            //NextÃ¢ ¶ç¿ì±â
            SceneManager.LoadScene(nowStage);
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
