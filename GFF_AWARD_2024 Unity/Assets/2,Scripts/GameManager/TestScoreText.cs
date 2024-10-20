using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScoreText : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public int score = 0;
    void Start()
    {
        if(tmpro == null)
        {
            tmpro = this.GetComponent<TextMeshProUGUI>();
        }
        tmpro.text = $"{score}";
    }

    void Update()
    {
        if(score != ScoreManager.instance.GetScore())
        {
            score = ScoreManager.instance.GetScore();
            tmpro.text = $"{score}";
        }
    }
}
