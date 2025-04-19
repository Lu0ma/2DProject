using System.Collections;
using UnityEngine;

public class DeathState : State
{
    MobMovementComponent movementRef = null;
    float DestroyTimer = 3.0f; 
    public DeathState(FSM _fsm, GameObject _owner) : base(_fsm, _owner)
    {
        movementRef = owner.GetComponent<MobMovementComponent>();
    }

    public override void Enter()
    {
        movementRef.Animator.SetBool("Dead", true);
        DestroyAll();
        base.Enter();
    }
    public override IEnumerator Update()
    {

        yield return null;
    }
    public override void Exit()
    {
        base.Exit();
    }

    void DestroyAll()
    {
        MonoBehaviour.Destroy(owner, DestroyTimer);
    }


}
