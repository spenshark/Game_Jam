using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoodangFly : MonoBehaviour
{
    public float flySpeed = 0.02f;
    public GameObject itemPrefab; // 아이템 프리팹
    public float itemSpawnInterval = 2.0f; // 아이템 스폰 간격

    void Start()
    {
        // 주기적으로 SpawnMoodang 함수를 호출하여 객체를 스폰
        InvokeRepeating("SpawnItem", 0f, itemSpawnInterval);
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(flySpeed * (-1), 0f);
        transform.Translate(moveDirection * Time.deltaTime);
    }

    void SpawnItem()
    {
        // 아이템 프리팹을 현재 Moodang 위치에 생성
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
