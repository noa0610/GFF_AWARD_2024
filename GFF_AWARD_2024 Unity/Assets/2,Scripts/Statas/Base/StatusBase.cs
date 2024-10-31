using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBase : MonoBehaviour
{
    public enum UnitType // プレイヤーか敵かを判断する列挙型
    {
        Player,
        Enemy
    }

    [SerializeField] private string unitName; // キャラクター名
    [SerializeField] private int hp; // 体力
    [SerializeField] private int atk; // 攻撃力
    [SerializeField] private UnitType unitType; // プレイヤーor敵

    public string UnitName => unitName; // 外部から読み取り専用でアクセス
    public int HP { get; protected set; } // 動的に変わるためプロパティで管理
    public int ATK { get; set; } // レベルアップなどで変更可能
    public UnitType Type => unitType;

    private void Awake()
    {
        HP = hp; // 初期HPをセット
        ATK = atk; // 初期ATKをセット
    }

    // ダメージを受けるメソッド
    public void TakeDamage(int damage)
    {
        HP -= damage;
        HP = Mathf.Max(HP, 0); // HPが0以下にならないようにする
        Debug.Log($"{UnitName} took {damage} damage. Remaining HP: {HP}");

        if (HP <= 0)
        {
            OnDeath();
        }
    }

    // 継承先での死亡時の挙動をオーバーライドするためのメソッド
    protected virtual void OnDeath()
    {
        Debug.Log($"{UnitName} has died.");
    }
}