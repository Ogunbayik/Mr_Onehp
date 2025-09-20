using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    
    public override void EnterState(EnemyBase enemy)
    {
        enemy.enemyAgent.isStopped = true;
        Debug.Log("Enter Attack State");
    }

    public override void ExitState(EnemyBase enemy)
    {
        Debug.Log("Exit Attack State");
    }

    public override void UpdateState(EnemyBase enemy)
    {
        Debug.Log("Update Attack State");
    }
}
