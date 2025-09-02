using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateController : MonoBehaviour
{
    public event Action<States> OnStateChanged;
    public enum States
    {
        Idle,
        Move,
        Attack
    }
    private States currentState;
    void Start()
    {
        currentState = States.Idle;
    }
    public void ChangeState(States newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
        OnStateChanged?.Invoke(newState);
    }
    public States GetCurrentState()
    {
        return currentState;
    }
}
