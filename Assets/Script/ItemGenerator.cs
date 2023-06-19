using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    int random = 0;
    float span = 5.0f;
    float delta = 0;

    public GameObject BItem;
    public GameObject GItem;
    public GameObject RItem;

    void Update()
    {
        delta += Time.deltaTime;

        if (span < delta)
        {
            delta = 0;
            random = Random.Range(0, 3);
            if(random ==0)
            {
                GameObject go = Instantiate(BItem);
                float py = Random.Range(-9f, 10f);
                go.transform.position = new Vector3(py, 5, 0);
            }

            else if (random == 1)
            {
                GameObject go = Instantiate(GItem);
                float py = Random.Range(-9f, 10f);
                go.transform.position = new Vector3(py, 5, 0);
            }
            else
            {
                GameObject go = Instantiate(RItem);
                float py = Random.Range(-9f, 10f);
                go.transform.position = new Vector3(py, 5, 0);
            }
        }
    }
}
