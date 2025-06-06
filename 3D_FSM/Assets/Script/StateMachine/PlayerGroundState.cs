using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    private Player player;

    public PlayerGroundState(PlayerStateMachine playerstateMachine) : base(playerstateMachine)
    {

    }

    
    protected override void OnMoveMentCaneceled(InputAction.CallbackContext context)
    {
        if (stateMachine.MovementInput == Vector2.zero)
        {
            return; 
        }

        stateMachine.ChangeState(stateMachine.IdleState); //기존에 입력있을때 
        base.OnMoveMentCaneceled(context);
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
