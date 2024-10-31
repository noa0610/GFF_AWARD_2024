using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBer : MonoBehaviour
{
    private Slider HPslider; // HPを表示するSlider
    private PlayerStatus playerStatus; // プレイヤーステータス

    void Start()
    {
        // Sliderコンポーネントを取得
        HPslider = GetComponent<Slider>();

        // プレイヤーステータスを検索
        playerStatus = FindObjectOfType<PlayerStatus>(); 
        if (playerStatus == null)
        {
            Debug.LogError("プレイヤーが見つかりません");
            return;
        }

        // スライダーの最大値と初期値を設定
        HPslider.maxValue = playerStatus.HP;
        HPslider.value = playerStatus.HP;
    }

    void Update()
    {
        if (playerStatus != null)
        {
            // プレイヤーのHPをスライダーに反映
            HPslider.value = playerStatus.HP;
        }
    }
}
