using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddScore : MonoBehaviour
{
    // スコアを増減するテストプログラム

    public int addscore = 5; // 増減するスコア
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) // スコアを増加
        {
            ScoreManager.instance.AddScore(addscore);
            Debug.Log("{addscore}");
        }

        if(Input.GetKeyDown(KeyCode.X)) // スコアを減少
        {
            ScoreManager.instance.AddScore(-addscore);
            Debug.Log("{-addscore}");
        }
    }
}
