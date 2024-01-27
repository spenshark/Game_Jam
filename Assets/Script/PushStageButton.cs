using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushStageButton : MonoBehaviour
{
    public  int buttonIndex;

    // Update is called once per frame
    public void PushStage()
    {
        Debug.Log("Push stage"+ buttonIndex);
        tmpGameManager.nowsa
        SceneManager.LoadScene(buttonIndex);
    }


}
