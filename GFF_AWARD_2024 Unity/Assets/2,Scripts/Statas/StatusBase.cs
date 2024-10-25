using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBase : MonoBehaviour
{
    public string CharacterName { get; set; }
    public int HP { get; protected set; }
    public int ATK { get; protected set; }

    // コンストラクタで初期設定
    public StatusBase(string name, int hp, int atk)
    {
        CharacterName = name;
        HP = hp;
        ATK = atk;
    }

    // ダメージを受けるメソッド
    public void TakeDamage(int damage)
    {
        HP -= damage;
        HP = Mathf.Max(HP, 0); // HPが0以下にならないようにする
        Debug.Log($"{CharacterName} took {damage} damage. Remaining HP: {HP}");

        // 継承先で特定の処理を実装するための仮想メソッド
        if (HP <= 0)
        {
            OnDeath();
        }
    }

    // 継承先での死亡時の挙動をオーバーライドするためのメソッド
    protected virtual void OnDeath()
    {
        Debug.Log($"{CharacterName} has died.");
    }
}