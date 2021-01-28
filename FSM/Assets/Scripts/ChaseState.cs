using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private Transform enemy;
    private Transform player;
    public float smooth = 3;
    public float chaseSpeed = 5;

    public ChaseState(FSMSystem fsm):base(fsm)
    {
        stateID = StateID.ChaseState;
        enemy = GameObject.FindWithTag("Enemy").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("敌人开始追逐玩家了！");
    }

    public override void DoAfterLeaving()
    {
        Debug.Log("敌人跟丢玩家，继续巡逻了！");
    }

    public override void Act()
    {
        Vector3 forward = player.position - enemy.position;
        forward = new Vector3(forward.x, 0, forward.z);
        Quaternion targetQuaternion = Quaternion.LookRotation(forward, Vector3.up);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, targetQuaternion, Time.deltaTime * smooth);
        enemy.Translate(Vector3.forward * Time.deltaTime * chaseSpeed);  
    }

    public override void Reason()
    {
        if (Vector3.Distance(enemy.position, player.position) > 8)
        {
            fsm.PerformTransition(Transition.LosePlayer);
        }
    }
}
