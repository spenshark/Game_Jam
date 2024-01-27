using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_hit : MonoBehaviour
{
    Rigidbody2D rigid;

    public float maxSpeed;
    public float moveSpeed = 5f; // ÆÄµµÀÇ ÀÌµ¿ ¼Óµµ

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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ÆÄµµ¶û ºÎµúÈû");
            // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
