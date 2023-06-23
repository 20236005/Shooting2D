using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContoroller : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    public void Gameback()
    {
        SceneManager.LoadScene("GameScene");
    }
}
