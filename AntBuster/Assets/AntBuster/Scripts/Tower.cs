using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //////////////////////////////////////////////////////////
    // 변수의 선언


    //towerDMG = 포탑의 공격력을 설정해준다.
    public int towerDMG { get; private set; } = 2;

    // fireRate = 포탑 발사속도를 설정해준다. 
    public float fireRate { get; private set; } = 1.5f;

    // timeAfterFire = 포탑 발사속도에 비교될 타이머를 설정해준다.
    private float timeAfterFire;

    // towerRigid = 타워의 리지드 바디를 설정해준다.
    private Rigidbody2D towerRigid;

    // bulletPrefabs = 타워가 발사할 탄환의 prefab을 설정해준다.
    public GameObject bulletPrefabs;

    // targetPosition = 타워의 콜라이더에서 검출된 개미의 위치를 저장할 변수를 설정해준다.
    public Vector2 targetPosition;

    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Awake 함수

    private void Awake()
    {
        // towerRigid 의 의 rigidbody를 만들어줌
        towerRigid = GetComponent<Rigidbody2D>();
        // 콜라이더에 개미를 감지하자 마자 바로 발사할 수 있도록 timeAfterFire 를 채워놓음
        timeAfterFire = fireRate;
    }
    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // 트리거 머물기

    private void OnTriggerStay2D(Collider2D collision)
    {
        // [조건문] : 부딪힌 콜라이더의 태그가 Ant라면,
        if (collision.tag.Equals("Ant"))
        {
            // Debug.Log("개미 발견");
            // targetPosition 에 부딪힌 위치를 저장해준다.
            targetPosition = new Vector2(collision.transform.position.x, collision.transform.position.y);
            
            // [커스텀 메서드] : 아래에서 정의한 LookTarget 함수를 작동시킨다.
            LookTarget();

            // timeAfterFire 에 deltaTime으로 충전시킨다.
            timeAfterFire += Time.deltaTime;

            // [조건문] : 만약 timeAfterTime 타이머가 fireRate 보다 같거나 크면,
            if (timeAfterFire >= fireRate)
            {
                // [커스텀 메서드] : 아래에서 정의한 Fire 함수를 작동시킨다.
                Fire();
                timeAfterFire = 0;
            }
        }
    }
    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // 커스텀 메서드

    private void LookTarget() 
    {
        // targetDirection 에 (타워 콜라이더에서 검출한 좌표 - 타워 좌표) 를 저장한다.
        // Vector A - Vector B 의 의미 : B가 A로 가는 방향과 속도
        Vector2 targetDirection = targetPosition - (Vector2)transform.position;
        // Y축(transform.up)에 위에서 계산한 방향과 속도에서 방향만 뽑아온다.
        transform.up = targetDirection.normalized;
    }

    private void Fire() 
    {
        // bullet 변수를 인스턴스화한다.
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
        // bullet 스크립트의 tower가 현재 타워라는 것을 알려준다.
        bullet.GetComponent<Bullet>().Tower = this;
    }
    //////////////////////////////////////////////////////////
}

