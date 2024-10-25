using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : StatusBase
{
    public EnemyStatus(string name, int hp, int atk) : base(name, hp, atk) { }

    // 敵の死亡時の処理をオーバーライド
    protected override void OnDeath()
    {
        Debug.Log($"{CharacterName} has been defeated.");
        // 敵を消滅させる処理
        Destroy(gameObject);
    }
}
