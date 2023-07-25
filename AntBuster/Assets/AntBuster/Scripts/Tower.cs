using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //////////////////////////////////////////////////////////
    // ������ ����


    //towerDMG = ��ž�� ���ݷ��� �������ش�.
    public int towerDMG { get; private set; } = 2;

    // fireRate = ��ž �߻�ӵ��� �������ش�. 
    public float fireRate { get; private set; } = 1.5f;

    // timeAfterFire = ��ž �߻�ӵ��� �񱳵� Ÿ�̸Ӹ� �������ش�.
    private float timeAfterFire;

    // towerRigid = Ÿ���� ������ �ٵ� �������ش�.
    private Rigidbody2D towerRigid;

    // bulletPrefabs = Ÿ���� �߻��� źȯ�� prefab�� �������ش�.
    public GameObject bulletPrefabs;

    // targetPosition = Ÿ���� �ݶ��̴����� ����� ������ ��ġ�� ������ ������ �������ش�.
    public Vector2 targetPosition;

    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Awake �Լ�

    private void Awake()
    {
        // towerRigid �� �� rigidbody�� �������
        towerRigid = GetComponent<Rigidbody2D>();
        // �ݶ��̴��� ���̸� �������� ���� �ٷ� �߻��� �� �ֵ��� timeAfterFire �� ä������
        timeAfterFire = fireRate;
    }
    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Ʈ���� �ӹ���

    private void OnTriggerStay2D(Collider2D collision)
    {
        // [���ǹ�] : �ε��� �ݶ��̴��� �±װ� Ant���,
        if (collision.tag.Equals("Ant"))
        {
            // Debug.Log("���� �߰�");
            // targetPosition �� �ε��� ��ġ�� �������ش�.
            targetPosition = new Vector2(collision.transform.position.x, collision.transform.position.y);
            
            // [Ŀ���� �޼���] : �Ʒ����� ������ LookTarget �Լ��� �۵���Ų��.
            LookTarget();

            // timeAfterFire �� deltaTime���� ������Ų��.
            timeAfterFire += Time.deltaTime;

            // [���ǹ�] : ���� timeAfterTime Ÿ�̸Ӱ� fireRate ���� ���ų� ũ��,
            if (timeAfterFire >= fireRate)
            {
                // [Ŀ���� �޼���] : �Ʒ����� ������ Fire �Լ��� �۵���Ų��.
                Fire();
                timeAfterFire = 0;
            }
        }
    }
    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Ŀ���� �޼���

    private void LookTarget() 
    {
        // targetDirection �� (Ÿ�� �ݶ��̴����� ������ ��ǥ - Ÿ�� ��ǥ) �� �����Ѵ�.
        // Vector A - Vector B �� �ǹ� : B�� A�� ���� ����� �ӵ�
        Vector2 targetDirection = targetPosition - (Vector2)transform.position;
        // Y��(transform.up)�� ������ ����� ����� �ӵ����� ���⸸ �̾ƿ´�.
        transform.up = targetDirection.normalized;
    }

    private void Fire() 
    {
        // bullet ������ �ν��Ͻ�ȭ�Ѵ�.
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
        // bullet ��ũ��Ʈ�� tower�� ���� Ÿ����� ���� �˷��ش�.
        bullet.GetComponent<Bullet>().Tower = this;
    }
    //////////////////////////////////////////////////////////
}

