using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayBoredAnimation()
    {
        animator.SetTrigger("isBored");
    }
    public void PlayMoveAnimation(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }
}
