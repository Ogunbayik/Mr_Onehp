using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public override void EnterState(EnemyBase enemy)
    {
        enemy.enemyAgent.speed = enemy.enemySO.chaseSpeed;
        enemy.enemyAgent.SetDestination(enemy.player.transform.position);

        enemy.animationController.MoveAnimation(true);
    }

    public override void ExitState(EnemyBase enemy)
    {
        Debug.Log("Exit Chase State");
    }

    public override void UpdateState(EnemyBase enemy)
    {
        var distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.transform.position);
        if (distanceToPlayer <= enemy.enemySO.attackDistance)
            enemy.SwitchState(enemy.attackState);
       
        if (enemy.enemyAgent.remainingDistance > enemy.enemySO.chaseDistance)
            enemy.SwitchState(enemy.patrolState);

        enemy.HandleMovement(enemy.player.transform.position);
    }
}
