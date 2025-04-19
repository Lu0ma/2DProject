using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    float currentTime = 0.0f;
    float maxTime = 5.0f;
    MobMovementComponent movementRef = null;
    public IdleState(FSM _fsm, GameObject _owner) : base(_fsm, _owner)
    {
        movementRef = owner.GetComponent<MobMovementComponent>();
    }
    
    public override void Enter()
    {
        movementRef.Animator.SetBool("Idle", true);
        base.Enter();
    }
    public override IEnumerator Update()
    {
        currentTime += Time.deltaTime;
        yield return null;
    }
    public override void Exit()
    {
        movementRef.Animator.SetBool("Idle", false);
        base.Exit();
    }

    public bool FinishIdle()
    {
        if (currentTime > maxTime)
        {
            currentTime = 0.0f;
            return true;
        }
        return false;
    }
}
