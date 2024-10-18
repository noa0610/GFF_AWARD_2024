using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // シングルトンパターン

    private int score = 0; // スコアを保持する変数

    private void Awake()
    {
        // シングルトンインスタンスの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも破棄されないようにする
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は、重複しないように破棄
        }
    }

    // スコアを加算するメソッド
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
    }

    // 現在のスコアを取得するメソッド
    public int GetScore()
    {
        return score;
    }
}
