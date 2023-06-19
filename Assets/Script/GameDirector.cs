using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; // 距離を表示するUI-Textオブジェクトを保存
    int kyori ;              // 距離を保存する変数

    public Image TimeGauge; // タイムゲージを表示するUI-Imageオブジェクトを保存

    public static float lastTime;         // 残り時間を保存する変数

    // Start is called before the first frame update
    void Start()
    {
        kyori = 0;
        lastTime = 100f; 
    }

    // Update is called once per frame
    void Update()
    {
        if(kyori< 0)
        {
            kyori = 0;
        }
        // 残り時間を減らす処理
        lastTime -= Time.deltaTime * 2;
        TimeGauge.fillAmount = lastTime / 100f;

        // 残り時間が０になったらリロード
        if (lastTime < 0)
        {
            PlayerPrefs.SetInt("Scoer",kyori);
            PlayerPrefs.Save();
            SceneManager.LoadScene("TitleScene");
        }

        // 進んだ距離を表示
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km" ;
    }

    public void DecreaseTime()
    {
        //敵と衝突したら距離を減らす
        kyori -= 1000;
    }
    public void DecreaseTime2()
    {
        //敵弾と衝突したら距離を減らす
        kyori -= 300;
    }
    public void DecreaseTime3()
    {
        //敵を倒したら距離を増やす
        kyori += 500;
    }
}
