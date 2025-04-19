using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    MobMovementComponent movementRef = null;
    DetectionComponent detectionRef = null;
    public AttackState(FSM _fsm, GameObject _owner) : base(_fsm, _owner)
    {
        movementRef = owner.GetComponent<MobMovementComponent>();
        detectionRef = owner.GetComponent<DetectionComponent>();
    }

    public override void Enter()
    {
        movementRef.Animator.SetBool("Attack", true);
        movementRef.MoveSpeed = 1.0f;
        base.Enter();
    }
    public override IEnumerator Update()
    {
        movementRef.MoveToPlayer(detectionRef.PlayerDir);
        yield return null;
    }
    public override void Exit()
    {
        movementRef.Animator.SetBool("Attack", false);
        movementRef.MoveSpeed = 0.1f;
        base.Exit();
    }
}
