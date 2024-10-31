using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackBase
{
    private void Awake()
    {
        // 攻撃者のタイプをPlayerに設定
        attackerType = StatusBase.UnitType.Player;
    }
}
