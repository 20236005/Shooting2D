using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; // 距離を表示するUI-Textオブジェクトを保存
    //int kyori ;              // 距離を保存する変数

    GameObject Timegaugi;

    void Start()
    {
        //kyori = 0;
        //Time_gaugeの情報を取得する
        this.Timegaugi = GameObject.Find("Timegauge");
    }

    // Update is called once per frame
    void Update()
    {
        //if(kyori< 0)
        //{
        //    kyori = 0;
        //}

        if (this.Timegaugi.GetComponent<Image>().fillAmount == 0)
        {
            BgmManager.Instance.StopImmediately();
            SceneManager.LoadScene("TitleScene");
        }

        // 進んだ距離を表示
        //kyori++;
        //kyoriLabel.text = kyori.ToString("D6") + "km" ;
    }
    public void DecreaseTime()
    {
        //敵と衝突したらTimegaugeを減らす
        this.Timegaugi.GetComponent<Image>().fillAmount -= 0.25f;
    }
    public void DecreaseTime2()
    {
        //敵を撃破したらTimegaugeを増やす
        this.Timegaugi.GetComponent<Image>().fillAmount += 0.15f;
    }
    public void DecreaseTime3()
    {
        //敵と衝突したらTimegaugeを減らす
        this.Timegaugi.GetComponent<Image>().fillAmount -= 0.5f;
    }
    public void DecreaseTime4()
    {
        //敵と衝突したらTimegaugeを減らす
        this.Timegaugi.GetComponent<Image>().fillAmount -= 0.10f;
    }
    public void DecreaseTime5()
    {
        //GItemをゲットしたらTimugaugeを半分回復
        this.Timegaugi.GetComponent<Image>().fillAmount += 0.50f;
    }
}
