using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControllor : MonoBehaviour
{
    float speed = 0.050f;

    void Start()
    {
        // Žõ–½2.5•b
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        //ˆÚ“®
        transform.Translate(0, this.speed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

