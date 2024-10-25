using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrigerSceneChange : MonoBehaviour
{
    // すり抜けオブジェクトに触れた時シーン遷移
    [SerializeField] private string targetSceneName; // 遷移するシーン名

    private void OnTriggerEnter(Collider other) // オブジェクトがすり抜けた時
    {
        if(other.gameObject.tag == "Player") // オブジェクトが"Player"タグなら
        {
            // シングルトンのメソッドでシーン遷移をする
            SceneChangeManager.Instance.ChangeSceneLoad(targetSceneName);
        }
    }
}
