using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScripableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("Patrol Settings")]
    public float patrolSpeed;
    public float patrolRange;
    [Header("Looking Settings")]
    public float lookAngle;
    public float lookSpeed;
    public float maximumLookTime;
    public float minimumLookTime;
    public float maximumDurationTime;
    public float minimumDurationTime;
    [Header("Chase Settings")]
    public float chaseSpeed;
    public float chaseDistance;
    [Header("Attack Settings")]
    public float attackDistance;
}
