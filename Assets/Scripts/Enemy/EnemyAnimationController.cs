using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveAnimation(bool isActive)
    {
        animator.SetBool("isMoving", isActive);
    }
}
