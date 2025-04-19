using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    State currentState = null;
    Dictionary<State, List<Transition>> transitions = new Dictionary<State, List<Transition>>();

    public void SetNextState(State _state)
    {
        if(currentState != null)
            currentState.Exit();
        currentState = _state;
        currentState.Enter();
    }

    public void AddTransition(State _from, State _to, Func<bool> _cdt)
    {
        if(!transitions.ContainsKey(_from))
            transitions[_from] = new List<Transition>();
        transitions[_from].Add(new Transition(_cdt, _to));
    }

    public IEnumerator Update()
    {
        while(true)
        {
            if (currentState == null) yield break;
            List<Transition> transitionList = transitions.GetValueOrDefault(currentState);
            if(transitionList != null)
            {
                foreach (Transition transition in transitionList)
                { 
                    if(transition.Condition())
                    {
                        SetNextState(transition.NextState);
                        break;
                    }
                }
            }
            yield return currentState.Update();
        }
    }
}
