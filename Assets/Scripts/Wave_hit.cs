using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_hit : MonoBehaviour
{
    Rigidbody2D rigid;

    public float maxSpeed;
    public float moveSpeed = 5f; // �ĵ��� �̵� �ӵ�

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        if (transform.position.y < -2f)
        {
            DestroyWave();
        }
    }

    void DestroyWave()
    {
        // �ı� ���� ����� ���� �߰�

        // �ı� ���� Rigidbody2D�� ������� �ʵ��� ����
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0f;

        // �ı�
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        rigid = null;
    }
}
