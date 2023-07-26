using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //////////////////////////////////////////////////////////
    // 변수의 선언


    // bulletSpeed = 탄환의 속도를 설정해준다.
    public float bulletSpeed { get; private set; } = 8.0f;

    // bulletRigid = 탄환의 rigidbody를 설정해준다.
    private Rigidbody2D bulletRigid;

    // tower = 타워라는 게임 오브젝트를 값을 불러오기 위해 설정해준다.
    public Tower Tower;

    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Start 함수

    void Start()
    {
        // bulletRigid 의 rigidbody를 만들어줌
        bulletRigid = GetComponent<Rigidbody2D>();
        //tower = GetComponent<Tower>();

        // Debug.Log(tower == null);
        // bulletRigid 의 속도는 tower의 콜라이더에서 받아온 targetPosition 에 탄환속도를 곱해준다.
        bulletRigid.velocity = (Tower.targetPosition - Tower.transform.position) * bulletSpeed;
        // 생성된 탄환을 8.0f 뒤에 삭제한다.
        Destroy(gameObject, 8.0f);
    }
    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // 트리거 진입

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // [조건문] : 부딪힌 콜라이더의 태그가 Ant라면,
        if (collision.transform.tag == "Ant") 
        {
            // 조건에 맞다면 생성된 탄환을 삭제한다.
            Destroy(gameObject);
        }
    }
    //////////////////////////////////////////////////////////
}
