using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    MobMovementComponent movementRef = null;
    //DetectionComponent detectionRef = null;
    float currentTime = 0.0f;
    float maxTime = 5.0f;

    public WalkState(FSM _fsm, GameObject _owner) : base(_fsm, _owner)
    {
        movementRef = owner.GetComponent<MobMovementComponent>();
        //detectionRef = owner.GetComponent<DetectionComponent>();
    }

    public override void Enter()
    {
        movementRef.Animator.SetBool("Walk", true);
        base.Enter();
    }

    public override IEnumerator Update()
    {
        currentTime += Time.deltaTime;
        movementRef.Move();
        yield return null;
    }

    public override void Exit()
    {
        movementRef.Animator.SetBool("Walk", false);
        base.Exit();
    }

    public bool FinishWalk()
    {
        if (currentTime > maxTime)
        {
            currentTime = 0.0f;
            return true;
        }
        return false;
    }
}