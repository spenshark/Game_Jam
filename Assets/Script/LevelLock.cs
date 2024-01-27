using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    int openLevel = 1;  //���� �������� ��ȣ
    public GameObject stageNum; //�������� ��ư��

    // Start is called before the first frame update
    void Start()
    {
        Button[] stages = stageNum.GetComponentsInChildren<Button>();

        openLevel = PlayerPrefs.GetInt("levelReached");
        for (int i = openLevel + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
            //Ŭ������� ���� ��������(i+1��° �̻�) ��ư�� ��Ȱ��ȭ
        }
    }

}
