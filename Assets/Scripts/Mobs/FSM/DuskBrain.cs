using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuskBrain : MonoBehaviour
{
    Animator animator = null;
    FSM duskFSM = null;
    StatComponent stat = null;
    DetectionComponent detection = null;
     
    public DetectionComponent Detection => detection;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stat = GetComponent<StatComponent>();
        detection = GetComponent<DetectionComponent>();
        InitFSM();
    }

    private void InitFSM()
    {
        duskFSM = new FSM();

        //create states
        IdleState _idle = new IdleState(duskFSM, gameObject);
        AttackState _attack = new AttackState(duskFSM, gameObject);
        DeathState _death = new DeathState(duskFSM, gameObject);
        WalkState _walk = new WalkState(duskFSM, gameObject);

        //init transition
        duskFSM.AddTransition(_idle, _walk, _idle.FinishIdle);
        duskFSM.AddTransition(_idle, _attack, () => detection.IsTarget);
        duskFSM.AddTransition(_idle, _death, () => stat.IsDead);

        duskFSM.AddTransition(_walk, _idle, _walk.FinishWalk);
        duskFSM.AddTransition(_walk, _attack, () => detection.IsTarget);
        duskFSM.AddTransition(_walk, _death, () => stat.IsDead);

        duskFSM.AddTransition(_attack, _walk, () => !detection.IsTarget);
        duskFSM.AddTransition(_attack, _idle, () => !detection.IsTarget);
        duskFSM.AddTransition(_attack, _death, () => stat.IsDead);

        //set nextstate (the first one who's played)
        duskFSM.SetNextState(_idle);

        StartCoroutine(duskFSM.Update());
    }
    private void Update()
    {
        
    }
}
