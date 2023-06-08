using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    float speed = 5.0f;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        dir = Vector3.left;

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy");
    }
}
