using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; // ������\������UI-Text�I�u�W�F�N�g��ۑ�
    //int kyori ;              // ������ۑ�����ϐ�

    GameObject Timegaugi;

    void Start()
    {
        //kyori = 0;
        //Time_gauge�̏����擾����
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

        // �i�񂾋�����\��
        //kyori++;
        //kyoriLabel.text = kyori.ToString("D6") + "km" ;
    }
    public void DecreaseTime()
    {
        //�G�ƏՓ˂�����Timegauge�����炷
        this.Timegaugi.GetComponent<Image>().fillAmount -= 0.25f;
    }
    public void DecreaseTime2()
    {
        //�G�����j������Timegauge�𑝂₷
        this.Timegaugi.GetComponent<Image>().fillAmount += 0.15f;
    }
    public void DecreaseTime3()
    {
        //�G�ƏՓ˂�����Timegauge�����炷
        this.Timegaugi.GetComponent<Image>().fillAmount -= 0.5f;
    }
    public void DecreaseTime4()
    {
        //�G�ƏՓ˂�����Timegauge�����炷
        this.Timegaugi.GetComponent<Image>().fillAmount -= 0.10f;
    }
    public void DecreaseTime5()
    {
        //GItem���Q�b�g������Timugauge�𔼕���
        this.Timegaugi.GetComponent<Image>().fillAmount += 0.50f;
    }
}
