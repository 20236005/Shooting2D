using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContller : MonoBehaviour
{
    Vector3 dir = Vector3.zero; // �ړ�������ۑ�����ϐ�

    Animator anim;// �A�j���[�^�[�R���|�[�l���g�̏���ۑ�����ϐ�

    public GameObject shot;
    public GameObject Player;

    float speed = 5;
    float timer;
    int power = 0;

    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;

        // ��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // �v���C���[�̈ʒu
        Vector3 PlayerPos = this.Player.transform.position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y, 0);

        // �A�j���[�V�����ݒ�
        if (dir.y == 0)
        {
            // �A�j���[�V�����N���b�v�yPlayer�z���Đ�
            anim.Play("Player");
        }
        else if (dir.y == 1)
        {
            anim.Play("PlayerL");
        }
        else if (dir.y == -1)
        {
            anim.Play("PlayerR");
        }

        timer += Time.deltaTime;

        if(power >5)
        {
            power = 5;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
        }

        if (Input.GetKey(KeyCode.Z) && timer > 0.5f)
        {
            for (int i = -power; i < power + 1; i++)
            {
                Vector3 ps = transform.position;
                Vector3 r = transform.root.eulerAngles + new Vector3(0, 0, 15f * i);
                Quaternion rot = Quaternion.Euler(r);

                Instantiate(shot, ps, rot);
            }
            timer = 0;
        }
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "GItem")
            {
                this.speed += 5.0f;
            }
            if (other.gameObject.tag == "BItem")
            {
                this.speed = 3.0f;
                this.power = 0;
            }
            if (other.gameObject.tag == "RItem")
            {
            this.power = (power + 1) % 13;
            }
        }   
}