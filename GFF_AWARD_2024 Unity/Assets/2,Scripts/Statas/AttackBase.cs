using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1; // 攻撃のダメージ
    [SerializeField] private float attackRange = 5f; // 攻撃の範囲
    [SerializeField] protected StatusBase.UnitType attackerType; // 攻撃を与えるユニットのタイプ

    private string targetTag; // 攻撃対象のタグ

    private void Start()
    {
        // attackerTypeに応じて攻撃対象のタグを設定
        targetTag = (attackerType == StatusBase.UnitType.Player) ? "Enemy" : "Player";
    }

    protected void OnTriggerEnter(Collider other)
    {
        // 攻撃対象のタグを持つオブジェクトに触れたか確認
        if (other.CompareTag(targetTag))
        {
            // ステータススクリプトを取得し、TakeDamageを呼び出して攻撃
            StatusBase targetStatus = other.GetComponent<StatusBase>();
            if (targetStatus != null)
            {
                targetStatus.TakeDamage(attackDamage);
                Debug.Log($"{attackerType} attacked {other.gameObject.name} with {attackDamage} damage.");
            }
        }
    }
}