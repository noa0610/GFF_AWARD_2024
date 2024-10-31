using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackBase
{
    private void Awake()
    {
        // 攻撃者のタイプをEnemyに設定
        attackerType = StatusBase.UnitType.Enemy;
    }
}
