using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    private Vector3 randomPosition;
    public override void EnterState(EnemyBase enemy)
    {
        randomPosition = GetRandomPosition(enemy);
        enemy.enemyAgent.speed = enemy.enemySO.patrolSpeed;
        enemy.enemyAgent.SetDestination(randomPosition);

        enemy.animationController.MoveAnimation(true);
    }

    public override void ExitState(EnemyBase enemy)
    {
        enemy.animationController.MoveAnimation(false);
    }

    public override void UpdateState(EnemyBase enemy)
    {
        var distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.transform.position);
        if (distanceToPlayer <= enemy.enemySO.chaseDistance)
            enemy.SwitchState(enemy.chaseState);

        if (enemy.transform.position == enemy.enemyAgent.pathEndPosition)
            enemy.SwitchState(enemy.lookState);

        enemy.HandleMovement(randomPosition);
    }

    private Vector3 GetRandomPosition(EnemyBase enemy)
    {
        var maximumX = enemy.startPosition.x + enemy.enemySO.patrolRange;
        var minimumX = enemy.startPosition.x - enemy.enemySO.patrolRange;
        var maximumZ = enemy.startPosition.z + enemy.enemySO.patrolRange;
        var minimumZ = enemy.startPosition.z - enemy.enemySO.patrolRange;

        var randomX = Random.Range(minimumX, maximumX);
        var randomZ = Random.Range(minimumZ, maximumZ);

        var randomPos = new Vector3(randomX, 0f, randomZ);
        return randomPos;
    }
}
