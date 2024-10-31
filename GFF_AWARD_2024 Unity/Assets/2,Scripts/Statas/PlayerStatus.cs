using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : StatusBase
{
    // レベルアップ用変数（仮）
    public int Experience { get; private set; } // 経験値
    public int Level { get; private set; } // レベル


    // プレイヤーの死亡時の処理をオーバーライド
    protected override void OnDeath()
    {
        Debug.Log("Game Over! The player has died.");
        // ゲームオーバーの処理を追加
        // 例えば、ゲームオーバー画面の表示など
    }

    // // 経験値取得用メソッド（仮）
    // public void GainExperience(int xp)
    // {
    //     Experience += xp;
    //     if (Experience >= GetExperienceForNextLevel()) // 次のレベルに必要な経験値に達したら
    //     {
    //         LevelUp();
    //     }
    // }

    // // レベルアップ用メソッド（仮）
    // private void LevelUp()
    // {
    //     Level++;
    //     ATK += 10; // 攻撃力を増加させる例
    //     HP += 20;  // 最大HPを増加させる例
    // }
}