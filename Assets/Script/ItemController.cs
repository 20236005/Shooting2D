using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    float speed = 3.0f;

    Vector3 dir = Vector3.zero;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {

        // �ړ�����������
        dir = Vector3.down;

        // ���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    //�����蔻��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
