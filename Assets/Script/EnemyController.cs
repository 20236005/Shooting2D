using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemyshot;
    public GameObject ExploPre;
    Vector3 dir ;
    float speed = 5;            // 移動速度
    float delta = 0;
    float span = 1.5f;
    float rad;
    int enemyType;

    Animator anim;

    void Start()
    {
        // 寿命4秒
        Destroy(gameObject, 4f);
        enemyType = Random.Range(0, 3);
        rad = Time.time;
        dir = Vector3.left;

        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }

        // 現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;
            GameObject go = Instantiate(Enemyshot);
            go.transform.position = this.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject dir = GameObject.Find("GameDirector");
            dir.GetComponent<GameDirector>().DecreaseTime();
            Instantiate(ExploPre, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "shot")
        {
            GameObject dir = GameObject.Find("GameDirector");
            dir.GetComponent<GameDirector>().DecreaseTime3();
            Instantiate(ExploPre, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

