using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre;
    float delta;
    float span;

    void Start()
    {
        delta = 0;
        span = 1.0f;
    }

    void Update()
    {
        delta += Time.deltaTime;

        if(delta > span )
        {
            delta = 0;  
            
            GameObject go = Instantiate(enemyPre);
            float py = Random.Range(-5f, 5f);
            go.transform.position = new Vector3(10, py, 0);
     
           span += (span >= 0.5f) ? 0.01f : 0f;
        }
    }
}
