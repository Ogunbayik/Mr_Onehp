using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private PlayerAnimationController animationController;
    private PlayerStateController stateController;

    [Header("Move Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [Header("Visual Settings")]
    [SerializeField] private GameObject playerVisual;
    [Header("Timer Settings")]
    [SerializeField] private float maxBoredTimer;

    private float horizontalInput;
    private float verticalInput;
    private float boredTimer;

    private Vector3 movementDirection;

    private bool isBored;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        stateController = GetComponent<PlayerStateController>();
        animationController = GetComponentInChildren<PlayerAnimationController>();
    }
    private void Start()
    {
        boredTimer = maxBoredTimer;
        movementDirection = Vector3.zero;
    }
    void Update()
    {
        HandleBoredAnimation();

        if (IsMoving())
            stateController.ChangeState(PlayerStateController.States.Move);
        else
            stateController.ChangeState(PlayerStateController.States.Idle);

        HandleMovement();
        HandleRotation();
    }
    private void HandleBoredAnimation()
    {
        var currentState = stateController.GetCurrentState();
        if (currentState != PlayerStateController.States.Idle || isBored)
            return;
        
        boredTimer -= Time.deltaTime;
        if(boredTimer <= 0)
        {
            isBored = true;
            boredTimer = maxBoredTimer;
            animationController.PlayBoredAnimation();
        }
    }
    private void HandleMovement()
    {
        isBored = false;

        horizontalInput = Input.GetAxis(Consts.PlayerInput.HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(Consts.PlayerInput.VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = movementDirection.normalized;

        if (IsMoving())
        {
            playerRb.velocity = movementDirection * movementSpeed;
            animationController.PlayMoveAnimation(true);
        }
        else
        {
            playerRb.velocity = Vector3.zero;
            animationController.PlayMoveAnimation(false);
        }
    }
    private void HandleRotation()
    {
        if(IsMoving())
        {
            var visualForward = Vector3.RotateTowards(playerVisual.transform.forward, movementDirection, rotationSpeed * Time.deltaTime, 0f);
            var visualRotation = Quaternion.LookRotation(visualForward);

            playerVisual.transform.rotation = visualRotation;
        }
    }
    private bool IsMoving()
    {
        return movementDirection != Vector3.zero;
    }
}
