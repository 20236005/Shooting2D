using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemyController : MonoBehaviour
{
    public int Hp;
    int damezi = 0;
    float span = 1.0f;
    float delt = 0f;
    float Speedx = 0f;
    float Speedy = 0f;
    float time = 0f;
    float xLimit = 9.0f;
    float yLimit = 5.0f;

    GameObject Boss;
    public GameObject Enemyshot;

    void Start()
    {
        this.Boss = GameObject.Find("BossEnemy");
        BgmManager.Instance.Play("BGM1");
    }

    void Update()
    {

        //ボスの位置
        Vector3 BossPos = this.Boss.transform.position;
        transform.position = new Vector3(BossPos.x, BossPos.y, 0);

        //移動制限
        Vector3 creentPos = transform.position;
        creentPos.x = Mathf.Clamp(creentPos.x, -xLimit, xLimit);
        creentPos.y = Mathf.Clamp(creentPos.y, -yLimit, yLimit);
        transform.position = creentPos;

        //速度
        transform.Translate(this.Speedx, this.Speedy, 0);

        this.time += Time.deltaTime;
        if (this.time >= 3f)
        {
            Speedx = Random.Range(0.10f, 0.01f);
            Speedy = Random.Range(-0.01f, 0.01f);
        }
        else if (this.time >= 1f)
        {
            Speedx = Random.Range(-0.10f, -0.01f);
            Speedy = Random.Range(-0.01f, 0.01f);
        }
        if (this.time >= 5.0f)
        {
            this.time = 0f;
        }

        if (damezi >= 20)
        {
            delt += Time.deltaTime;
            if(delt > span)
            {
                delt = 0;
                GameObject go = Instantiate(Enemyshot);
                go.transform.position = this.transform.position;
            }
        }
    }
    //当たり判定
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shot")
        {
            ++damezi;

            if (damezi == Hp)
            {
                BgmManager.Instance.StopImmediately();
                SceneManager.LoadScene("TitleScene");
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "Player")
        {
            GameObject dir = GameObject.Find("GameDirector");
            dir.GetComponent<GameDirector>().DecreaseTime3();
        }
    }
}
