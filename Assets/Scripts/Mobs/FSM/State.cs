using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FSM fsm = null;
    protected GameObject owner = null;

    public State(FSM _fsm, GameObject _owner)
    {
        fsm = _fsm;
        owner = _owner;
    }

    public virtual void Enter() { Debug.Log($"Enter State : {GetType().ToString()}"); }
    public virtual IEnumerator Update() { yield return null; }
    public virtual void Exit() { Debug.Log($"Exit State : {GetType().ToString()}"); }
}
