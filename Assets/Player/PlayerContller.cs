using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContller : MonoBehaviour
{
    public GameObject Shot;
    float speed = 1.0f;
    
    GameObject cher;

    float xLimit = 32.0f;
    float yLimit = 13.0f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        this.cher = GameObject.Find("MyChar");
        Application.targetFrameRate = 300;
    }

    void Update()
    {
        //�ړ����@
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;
        //�ړ�����
        Vector3 creentPos = transform.position;
        creentPos.x = Mathf.Clamp(creentPos.x, -xLimit, xLimit);
        creentPos.y = Mathf.Clamp(creentPos.y, -yLimit, yLimit);
        transform.position = creentPos;

        //�A�j���[�V����
        float y = Input.GetAxisRaw("Vertical");

        if (y == 0)
        {
            anim.Play("Player");
        }
        else if (y == 1)
        {
            anim.Play("PlayerL");
        }
        else
        {
            anim.Play("PlayerR");
        }

        // �v���C���[�̈ʒu
        Vector3 PlayerPos = this.cher.transform.position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y, 0);

        //�N���b�N������Shot��ł�
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(Shot);
            go.transform.position = new Vector3(PlayerPos.x, PlayerPos.y, 0);
        }

        anim.speed = speed / 2.0f;

    }
}