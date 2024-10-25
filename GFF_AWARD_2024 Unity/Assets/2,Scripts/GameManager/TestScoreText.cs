using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScoreText : MonoBehaviour
{
    public TextMeshProUGUI tmpro; // 変更するテキスト
    public int score = 0; // テキストのスコア
    void Start()
    {
        if(tmpro == null)
        {
            tmpro = this.GetComponent<TextMeshProUGUI>();
        }
        tmpro.text = $"{score}"; // テキストにスコアを反映
    }

    void Update()
    {
        if(score != ScoreManager.instance.GetScore()) // テキストのスコアとScoreManagerのスコアに違いがあれば
        {
            score = ScoreManager.instance.GetScore(); // ScoreManagerのスコアを反映
            tmpro.text = $"{score}"; // テキストのスコアを変更
        }
    }
}
