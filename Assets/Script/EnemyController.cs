using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemyshot;
    public GameObject ExploPre;
    public GameObject BItem;
    public GameObject GItem;
    public GameObject RItem;
    Vector3 dir ;
    float speed = 5;            // ˆÚ“®‘¬“x
    float delta = 0;
    float span = 1.5f;
    float rad;
    int enemyType;
    int random = 0;

    Animator anim;

    void Start()
    {
        // Žõ–½4•b
        Destroy(gameObject, 4.5f);
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

        // Œ»Ý’n‚ÉˆÚ“®—Ê‚ð‰ÁŽZ
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
            dir.GetComponent<GameDirector>().DecreaseTime2();
            Instantiate(ExploPre, transform.position, transform.rotation);

            random = Random.Range(0, 3);
            if (random == 0)
            {
               Item();
            }

            Destroy(gameObject);
        }
    }
    public void Item()
    {
        random = Random.Range(0, 3);
        if (random == 0)
        {
            GameObject go = Instantiate(BItem);
            go.transform.position = this.transform.position;
        }

        else if (random == 1)
        {
            GameObject go = Instantiate(GItem);
            go.transform.position = this.transform.position;
        }
        else
        {
            GameObject go = Instantiate(RItem);
            go.transform.position = this.transform.position;
        }
    }
}

