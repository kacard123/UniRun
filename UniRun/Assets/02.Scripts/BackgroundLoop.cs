using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ �̵��� ����� ������ ������ ���ġ ó��
public class BackgroundLoop : MonoBehaviour
{
    // ����� ���� ����
    private float width;
    
    // Unity Event Method
    private void Awake()
    {
        //Awake() �޼���� Star() �޼���ó�� �ʱ� 1ȸ �ڵ� ����Ǵ�
        //����Ƽ �̺�Ʈ �ż����Դϴ�. ������
        //Start() �޼��庸�� ��������� �� ������ �� �����ϴ�.
        //�����ϼ��� : Unity Method LifeCycle

        //���� ���̸� �����Ѵ�.
        //BoxCollider2D ������Ʈ�� Size�ʵ��� X���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ��ġ�� �������� �������� width �̻� �̵����� �� 
        //��ġ�� ���ġ
        if(transform.position.x <= -width)
        {
            Reposition();
        }


    }
    void Reposition() // ��ġ�� ���ġ�ϴ� �޼���
    {
        // ���� ��ġ���� ���������� ���� ���� * 2 ��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        // width : 20.48 * 2 = 40.48
        // -20.48 + 40.48 = 20.48

    }
}
