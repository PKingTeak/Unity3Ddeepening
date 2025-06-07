using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//점프하면서 마우스휠로 조작이 가능하고 즉 동시에 여러개의 입력을 처리하기 위한 State
public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerstateMachine)
    {

        stateMachine = playerstateMachine;
        groundData = stateMachine.Player.Data.GroundData;

    }
    public virtual void Enter()
    {
        AddInpuActionCallBack();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallBack();
    }

    public virtual  void HandleInput()
    {
        ReadMovementInput();


    }

    public virtual  void PhysicsUpdate()
    {
        
    }

    public virtual  void Update()
    {
        Move();
    }

    protected void StartAnimation(int animatorHash) //모든 state에 필요하기 때문에 
    {
        stateMachine.Player.Animator.SetBool(animatorHash, true);
        
    }
    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Player.Animator.SetBool(animatorHash, false);
    }


    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.playerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDir = GetMovementDirection();

        Move(movementDir);

        Rotate(movementDir);

    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x;

    }

    protected virtual void AddInpuActionCallBack()
    {
        PlayerController input = stateMachine.Player.Input;
        input.playerActions.Movement.canceled += OnMoveMentCaneceled;
        input.playerActions.Run.started += OnRunStarted;

    }

    protected virtual void RemoveInputActionsCallBack()
    {
        PlayerController input = stateMachine.Player.Input;
        input.playerActions.Movement.canceled -= OnMoveMentCaneceled;
        input.playerActions.Run.started -= OnRunStarted;

    }
    
    

    private float GetMovementSpeed()
    {

        float moveSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        return moveSpeed;

    }

    protected virtual void OnMoveMentCaneceled(InputAction.CallbackContext context)
    { 
        
    }

    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    { 
        
    }

    private void Move(Vector3 dir)
    {
        float movementSpeed = GetMovementSpeed();


        stateMachine.Player.Controller.Move(((dir * movementSpeed)+ stateMachine.Player.ForceReciver.movement)*Time.deltaTime);
    }


    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }
}
