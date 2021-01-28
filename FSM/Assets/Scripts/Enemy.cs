using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private FSMSystem fsm;

    private void Start()
    {
        fsm = new FSMSystem();
        FSMState patrolState = new PatrolState(fsm);
        FSMState chaseState = new ChaseState(fsm);
        fsm.AddState(patrolState);
        fsm.AddState(chaseState);
        patrolState.AddTransition(Transition.FindPlayer, StateID.ChaseState);
        chaseState.AddTransition(Transition.LosePlayer, StateID.PatrolState);
    }

    private void Update()
    {
        fsm.UpdateFSM();
    }
}
