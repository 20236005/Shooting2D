using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerContller : MonoBehaviour
{
    public GameObject Shot;
    float speed = 5.0f;
    
    GameObject player;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        this.player = GameObject.Find("MyChar");
        Application.targetFrameRate = 300;
    }

    void Update()
    {
        //移動方法
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;
        //移動制限
        Vector3 creentPos = transform.position;
        creentPos.x = Mathf.Clamp(creentPos.x, -9, 9);
        creentPos.y = Mathf.Clamp(creentPos.y, -5, 5);
        transform.position = creentPos;

        //アニメーション
        float y = Input.GetAxisRaw("Vertical");

        if (dir.y == 0)
        {
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
    }
}