using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddScore : MonoBehaviour
{
    // スコアを増減するテストプログラム

    public int addscore = 5;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ScoreManager.instance.AddScore(addscore);
            Debug.Log("{addscore}");
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            ScoreManager.instance.AddScore(-addscore);
            Debug.Log("{-addscore}");
        }
    }
}
