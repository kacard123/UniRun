using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerController�� �÷��̾� ĳ���ͷμ�
//Player ���� ������Ʈ�� ������.
public class PlayerController : MonoBehaviour
{
    // �÷��̾ ��� �� ����� ����� Ŭ�� 
    public AudioClip deathClip;
    // ���� ��
    public float jumpForce = 700f;

    // ���� ���� Ƚ�� 
    private int jumpCount = 0;
    // �÷��̾ �ٴڿ� ��Ҵ��� Ȯ��
    private bool isGrounded = false;
    // �÷��̾ �׾��� ��ҳ� = ��� ���¸� ������ �� �ִ�
    private bool isDead = false;
    // ����� ������ٵ� ������Ʈ
    private Rigidbody2D playerRigidbody;
    // ����� ����� �ҽ� ������Ʈ
    private AudioSource playerAudio;
    // ����� �ִϸ����� ������Ʈ
    private Animator animator;

    
    void Start()
    {
        // ���������� �ʱ�ȭ ����
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        // ����� �Է��� �����ϰ� �����ϴ� ó��
        // 1. ���� ��Ȳ�� �˸��� �ִϸ��̼��� ���.
        // 2. ���콺 ���� Ŭ���� �����ϰ� ����
        // 3. ���콺 ���� ��ư�� ���� ������ ���� ����
        // 4. �ִ� ���� Ƚ���� �����ϸ� ������ ���ϰ� ����

        // ��� �� ���̻� ó���� �������� �ʰ� ����
        if (isDead) return;

        // ���콺 ���� ��ư�� �������� & �ִ� ���� Ƚ�� 2ȸ�� �������� �ʾҴٸ�,
        if (Input.GetMouseButtonDown(0) && jumpCount<2)
        {
            // ���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0,0)�� ����
            // = ���� ���������� �� �Ǵ� �ӵ��� ���ǰų� �������� 
            // ���� ���̰� ���ϰ������� �Ǵ� ������ ���� ���ؼ� 
            playerRigidbody.velocity = Vector2.zero;

                                                    
            // ������ٵ� �������� ���ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            // ����� �ҽ� ��� 
            playerAudio.Play();
            
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)

        {
            // ���콺 ���� ��ư���� ���� ���� ������ �ӵ��� y���� ������ 
            //(���� ��� ��)
            // ���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
            
        }
        //�ִϸ������� Grounded�Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);

    }

    void Die()
    {
        // ��� ó��
        // animator�� DieƮ���� �Ķ���͸� ��
        animator.SetTrigger("Die");

        // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathclip���� ����
        playerAudio.clip = deathClip;
        // ��� ȿ���� ���
        playerAudio.Play();

        // �ӵ��� ����(0, 0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // �� ����߾�~ ��� ���¸� true�� ����
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� ���ڸ��� �����ϴ� ó�� ����
        // � �ݶ��̴��� �������, �浹 ǥ���� ������ ���� �ִ���

        if(collision.contacts[0].normal.y > 0.7f)
        {
            // contact : �浹 �������� ������ ��� ContactPoint Ÿ���� �����͸� contacts��� �迭 ������ �����޴´�.
            // normal : �浹 �������� �浹 ǥ���� ����(�븻����)�� �˷��ִ� ����.
            // isGrounded�� true�� �����ϰ�, ���� ���� Ƚ����
            // 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // �ٴڿ��� ����ڸ��� ó�� 

        // �Ʒ����� � collider���� ������ ��� isGrounded�� false�� ����
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �⵿ ����

        // �浹�� ������ �±װ� Dead�̸鼭, ���� ������� �ʾҴٸ� 
        if(collision.tag == "Dead" && !isDead)
        {
            Die();
        }

    }
}

