using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    float speed = 1.5f;
    Vector3 dir =  Vector3.zero;

    void Start()
    {
        // Žõ–½2.5•b
        Destroy(gameObject, 2.5f);
        GameObject play = GameObject.Find("Player");

        dir = play.transform.position - transform.position;

        //PlayerPosition = playerObject.transform.position;
        //EnemyShotPosition = transform.position;
        //EnemyShotPosition.x += (PlayerPosition.x - EnemyShotPosition.x) ;
        //EnemyShotPosition.y += (PlayerPosition.y - EnemyShotPosition.y) ;
    }

    void Update()
    {
        //transform.Translate(EnemyShotPosition.x * speed,EnemyShotPosition.y * speed , 0);
        if(dir.x > 4 && dir.y > 4)
        {
            dir.x = 4;
            dir.y = 4;
        }

        transform.position += dir * speed *Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject dir = GameObject.Find("GameDirector");
            dir.GetComponent<GameDirector>().DecreaseTime4();
            Destroy(gameObject);
        }
    }
}
