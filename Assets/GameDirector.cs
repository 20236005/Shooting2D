using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;
    int Kyori;

    float lastTime;

    public Image TimeGauge;

    void Start()
    {
        Kyori = 0;
        lastTime = 100f;
    }

    void Update()
    {
        lastTime -= Time.deltaTime;
        TimeGauge.fillAmount = lastTime / 100;

        Kyori++;
        kyoriLabel.text = Kyori.ToString("D6") + "km";

        if(lastTime < 0)
        {
            SceneManager.LoadScene("GameScene");
        }

    }
}
