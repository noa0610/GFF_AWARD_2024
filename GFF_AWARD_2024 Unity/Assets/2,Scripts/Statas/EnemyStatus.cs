using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : StatusBase
{
    // 敵の死亡時の処理をオーバーライド
    protected override void OnDeath()
    {
        Debug.Log($"{UnitName} has been defeated.");
        // 敵を消滅させる処理
        Destroy(gameObject);
    }

    // // ウェーブ数に応じてステータスが上昇するメソッド(仮)
    // public void ScaleStats(int wave)
    // {
    //     HP = 50 + wave * 10; // ウェーブ数に応じてHP増加
    //     ATK = 5 + wave * 2;   // ウェーブ数に応じてATK増加
    // }
}
