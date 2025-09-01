using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private PlayerStateController stateController;

    [Header("Move Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [Header("Visual Settings")]
    [SerializeField] private GameObject playerVisual;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        stateController = GetComponent<PlayerStateController>();
    }
    void Update()
    {
        if (IsMoving())
            stateController.ChangeState(PlayerStateController.States.Move);
        else
            stateController.ChangeState(PlayerStateController.States.Idle);

        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(Consts.PlayerInput.HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(Consts.PlayerInput.VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = movementDirection.normalized;

        playerRb.velocity = movementDirection * movementSpeed;
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
