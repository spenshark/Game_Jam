using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoodangFly : MonoBehaviour
{
    public float flySpeed = 0.02f;
    public GameObject itemPrefab; // ������ ������
    public float itemSpawnInterval = 2.0f; // ������ ���� ����

    void Start()
    {
        // �ֱ������� SpawnMoodang �Լ��� ȣ���Ͽ� ��ü�� ����
        InvokeRepeating("SpawnItem", 0f, itemSpawnInterval);
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(flySpeed * (-1), 0f);
        transform.Translate(moveDirection * Time.deltaTime);
    }

    void SpawnItem()
    {
        // ������ �������� ���� Moodang ��ġ�� ����
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
