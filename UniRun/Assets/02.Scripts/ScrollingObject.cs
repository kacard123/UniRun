using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 오브젝트를 지속적으로 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동 속도
    
    //void Start()
   // {
        // 초당 speed의 속도로 왼쪽으로 평행이동 구현
        //transform.Translate(Vector3.left * speed);
        // 2D 게임은 Vector2(x,y)가 필요한데 Vector2를 써도 vector3로 자동변환된다.
        // 2D 개발은 백터2가 편하다.
        //new Vector3(-1, 0, 0);
        
   //  }

     
    void Update()
    {
        // 초당 speed의 속도로 왼쪽으로 평행이동 구현
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
