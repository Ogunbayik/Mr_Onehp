using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{
    public override void HandleMovement()
    {
        base.HandleMovement();
    }
    public override void HandleAttack()
    {
        var distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(distanceBetweenPlayer <= attackRange)
        {
            base.HandleAttack();
        }
    }
}
