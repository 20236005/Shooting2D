using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoerDirector : MonoBehaviour
{
    public Text kyoriLabel;

    void Start()
    {
        int Scoer = PlayerPrefs.GetInt("Scoer");
        kyoriLabel.text = "Scoer" + Scoer;
    }
    void Update()
    {if (Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

}
