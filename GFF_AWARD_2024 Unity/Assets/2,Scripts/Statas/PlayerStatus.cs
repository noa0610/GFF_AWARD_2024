using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : StatusBase
{
    public PlayerStatus(string name, int hp, int atk) : base(name, hp, atk) { }

    // プレイヤーの死亡時の処理をオーバーライド
    protected override void OnDeath()
    {
        Debug.Log("Game Over! The player has died.");
        // ゲームオーバーの処理を追加
        // 例えば、ゲームオーバー画面の表示など
    }
}