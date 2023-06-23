using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    //float speed = 3.0f;

    //Vector3 dir = Vector3.zero;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {

        // 移動方向を決定
       // dir = Vector3.down;

        // 現在地に移動量を加算
       // transform.position += dir.normalized * speed * Time.deltaTime;
    }

    //当たり判定
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
