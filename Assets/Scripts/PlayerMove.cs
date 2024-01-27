using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameManager gameManager;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer SpriteRenderer;
    Animator anim;
    public bool isJumping;
    CapsuleCollider2D capsule_pl;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer= GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isJumping = false;
        capsule_pl = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        // ����
        if (Input.GetButtonDown("Jump") && !isJumping) { 
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
        }
        // �ӵ� ����
        if (Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        // ��������Ʈ ����
        if (Input.GetButton("Horizontal"))
            SpriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        
        // �ִϸ��̼�
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) { 
                isJumping = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
            Debug.Log("�÷��̾ ����");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            // Point
            gameManager.getLoad += 1;

            // ������ ��Ȱ��ȭ
            collision.gameObject.SetActive(false);
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        // ü�� ����
        gameManager.HpDown();

        // ���̾� ����
        gameObject.layer = 11;

        // ����ȭ
        //SpriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // �ǰ� �� ����
        int direction = targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(direction * 10, 0.5f) * 100, ForceMode2D.Impulse);

        // �ִϸ��̼�
        anim.SetTrigger("doDamaged");
        Invoke("OffDamaged", 1);
    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        //SpriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDie()
    {

        SpriteRenderer.color = new Color(1, 1, 1, 0.4f);
        SpriteRenderer.flipY = true;
        capsule_pl.enabled = false;
        
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

    }
    void FixedUpdate()
    {
        // �����̱�
        float h = Input.GetAxisRaw("Horizontal")*20;

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // �ִ� �ӵ� ����
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

    /*
    // Landing platform
    if(rigid.velocity.y < 0){
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 1));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider != null){
            if (rayHit.distance < 0.5f)
                ;
        }
    } 
    */

    public void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }
        
    
}
