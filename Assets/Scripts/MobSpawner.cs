using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject mobPrefab; // ���� ������
    public float spawnInterval = 1f; // �� ���� ����
    public Transform spawnPoint; // ���� ������ ��ġ

    void Start()
    {
        // �ֱ������� SpawnMob �Լ��� ȣ���Ͽ� ���� ����
        InvokeRepeating("SpawnMob", 0f, spawnInterval);
    }

    void SpawnMob()
    {
        if (mobPrefab == null || spawnPoint == null)
        {
            Debug.LogError("mobPrefab �Ǵ� spawnPoint�� null�Դϴ�.");
            return;
        }

        Instantiate(mobPrefab, spawnPoint.position, Quaternion.identity);
    }

}
