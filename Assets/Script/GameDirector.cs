using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; // ������\������UI-Text�I�u�W�F�N�g��ۑ�
    int kyori ;              // ������ۑ�����ϐ�

    public Image TimeGauge; // �^�C���Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�

    public static float lastTime;         // �c�莞�Ԃ�ۑ�����ϐ�

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
        // �c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime * 2;
        TimeGauge.fillAmount = lastTime / 100f;

        // �c�莞�Ԃ��O�ɂȂ����烊���[�h
        if (lastTime < 0)
        {
            PlayerPrefs.SetInt("Scoer",kyori);
            PlayerPrefs.Save();
            SceneManager.LoadScene("TitleScene");
        }

        // �i�񂾋�����\��
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km" ;
    }

    public void DecreaseTime()
    {
        //�G�ƏՓ˂����狗�������炷
        kyori -= 1000;
    }
    public void DecreaseTime2()
    {
        //�G�e�ƏՓ˂����狗�������炷
        kyori -= 300;
    }
    public void DecreaseTime3()
    {
        //�G��|�����狗���𑝂₷
        kyori += 500;
    }
}
