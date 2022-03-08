using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� �ִ�.

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ����
    public Text scoreText; // ������ ����� UI�ؽ�Ʈ 
    public GameObject gameoverUI; // ���ӿ����� Ȱ��ȭ�� UI ������Ʈ

    private int score = 0; // ���� ����

    // ���� ���۰� ���ÿ� �̱����� ����
    private void Awake()
    {
        // Awake�� start���� ���� ���۵ȴ�.
        // �̱��� ���� instanse�� ��� �ֳ���?
        if (instance = null)
        {
            // instance�� ��� �ִٸ� �װ��� �� �ڽ��� �Ҵ�

            instance = this;

        }

        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� 
            //�Ҵ�Ǿ� �ִٸ�...

            // �ϳ��� ���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ�
            // �ڽ��� ���� ������Ʈ�� �ı�
            // Debug.Log("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!")
            Destroy(gameObject);
            
        }
            
    }
    
    // ���ӿ��� ���¿��� ������ ������� �� �ְ� �ϴ� ó��

    void Update()
    {
        // ���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ���Ѵٸ�...
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // GetActiveScene : ���� Ȱ��ȭ�Ǿ��ִ� ���� �̸��� �����Ͷ�
            // SceneManager.LoadScene(0);
            // SceneManager.LoadScene("���� ���� �̸�");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);�� 
            // ���� �� ���� ������ ���� �̸��� ������ �� �� �ֱ� �����̴�.
            // ��� ������ ������ �� �ֵ���.

        }
    }

    // ������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        // ���� ������ �ƴ϶��
        if (!isGameover) return;
        {
            // ������ ����
            score += newScore;
            scoreText.text = "Score : " + score;

        }
    }

    // �÷��̾� ĳ���Ͱ� ����� ���� ������ �����ϴ� �޼���
    public void OnPlayerDead()
    {
        isGameover = true;
        // ���ӿ��� UI Ȱ��ȭ (���ӿ�����Ʈ�� �ִ� ��Ƽ������ �̿��ؼ� 
        // TrueȰ��ȭ.
        gameoverUI.SetActive(true);
    }

}
