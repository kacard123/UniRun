using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ�� ���������� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // �̵� �ӵ�
    
    //void Start()
   // {
        // �ʴ� speed�� �ӵ��� �������� �����̵� ����
        //transform.Translate(Vector3.left * speed);
        // 2D ������ Vector2(x,y)�� �ʿ��ѵ� Vector2�� �ᵵ vector3�� �ڵ���ȯ�ȴ�.
        // 2D ������ ����2�� ���ϴ�.
        //new Vector3(-1, 0, 0);
        
   //  }

     
    void Update()
    {
        // �ʴ� speed�� �ӵ��� �������� �����̵� ����
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
