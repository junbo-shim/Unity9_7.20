using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //////////////////////////////////////////////////////////
    // ������ ����


    // bulletSpeed = źȯ�� �ӵ��� �������ش�.
    [SerializeField] 
    private float bulletSpeed = 8.0f;

    // bulletRigid = źȯ�� rigidbody�� �������ش�.
    private Rigidbody2D bulletRigid;

    // tower = Ÿ����� ���� ������Ʈ�� ���� �ҷ����� ���� �������ش�.
    public GameObject tower;

    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Start �Լ�

    void Start()
    {
        // bulletRigid �� rigidbody�� �������
        bulletRigid = GetComponent<Rigidbody2D>();
        //tower = GetComponent<Tower>();

        Debug.Log(tower == null);
        // bulletRigid �� �ӵ��� tower�� �ݶ��̴����� �޾ƿ� targetPosition �� źȯ�ӵ��� �����ش�.
        bulletRigid.velocity = tower.GetComponent<Tower>().targetPosition * bulletSpeed;
        // ������ źȯ�� 8.0f �ڿ� �����Ѵ�.
        Destroy(gameObject, 8.0f);
    }
    //////////////////////////////////////////////////////////



    //////////////////////////////////////////////////////////
    // Ʈ���� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // [���ǹ�] : �ε��� �ݶ��̴��� �±װ� Ant���,
        if (collision.transform.tag == "Ant") 
        {
            // ���ǿ� �´ٸ� ������ źȯ�� �����Ѵ�.
            Destroy(gameObject);
        }
    }
    //////////////////////////////////////////////////////////
}