using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookState : EnemyState
{
    private Vector3 currentAngle;
    private float maximumAngle;
    private float minimumAngle;

    private Quaternion firstRotation;
    private Quaternion secondRotation;
    private Quaternion desiredRotation;

    private float lookTimer;
    private float lookDuration;
    public override void EnterState(EnemyBase enemy)
    {
        lookTimer = GetRandomLookTime(enemy);
        lookDuration = GetRandomDuration(enemy);

        currentAngle = enemy.transform.rotation.eulerAngles;
        maximumAngle = currentAngle.y + enemy.enemySO.lookAngle;
        minimumAngle = currentAngle.y - enemy.enemySO.lookAngle;

        firstRotation = Quaternion.Euler(new Vector3(0f, maximumAngle, 0f));
        secondRotation = Quaternion.Euler(new Vector3(0f, minimumAngle, 0f));

        desiredRotation = firstRotation;
    }


    public override void UpdateState(EnemyBase enemy)
    {
        var distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.transform.position);
        if(distanceToPlayer <= enemy.enemySO.chaseDistance)
        {
            enemy.SwitchState(enemy.chaseState);
            return;
        }

        lookDuration -= Time.deltaTime;

        if (lookDuration <= 0)
            enemy.SwitchState(enemy.patrolState);

        LookAround(enemy);
    }
    public override void ExitState(EnemyBase enemy)
    {
        Debug.Log("Exit LookState");
    }

    private void LookAround(EnemyBase enemy)
    {
        if (enemy.transform.rotation == firstRotation)
        {
            lookTimer -= Time.deltaTime;
            if (lookTimer <= 0)
            {
                desiredRotation = secondRotation;
                lookTimer = GetRandomLookTime(enemy);
            }
        }
        else if (enemy.transform.rotation == secondRotation)
        {
            lookTimer -= Time.deltaTime;
            if (lookTimer <= 0)
            {
                desiredRotation = firstRotation;
                lookTimer = GetRandomLookTime(enemy);
            }
        }

        enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, desiredRotation, enemy.enemySO.lookSpeed * Time.deltaTime);
    }
    private float GetRandomDuration(EnemyBase enemy)
    {
        var randomDuration = Random.Range(enemy.enemySO.minimumDurationTime, enemy.enemySO.maximumDurationTime);
        return randomDuration;
    }

    private float GetRandomLookTime(EnemyBase enemy)
    {
        var randomTime = Random.Range(enemy.enemySO.minimumLookTime, enemy.enemySO.maximumLookTime);
        return randomTime;
    }
}
