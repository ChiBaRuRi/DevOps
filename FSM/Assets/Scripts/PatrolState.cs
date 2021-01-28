using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private Transform enemy;
    private Transform player;
    private List<Transform> pathsList = new List<Transform>();
    private int index = 0;

    public float smooth = 3;

    public PatrolState(FSMSystem fsm) : base(fsm)
    {
        stateID = StateID.PatrolState;
        enemy = GameObject.FindWithTag("Enemy").transform;
        player = GameObject.FindWithTag("Player").transform;
        Transform pathRoot = GameObject.Find("PathRoot").transform;
        foreach (Transform pathPoint in pathRoot)
        {
            pathsList.Add(pathPoint);
        }
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("敌人开始巡逻了！");
    }

    public override void DoAfterLeaving()
    {
        Debug.Log("敌人发现玩家，结束巡逻！");
    }

    public override void Act()
    {
        Vector3 forward = pathsList[index].position - enemy.position;
        forward = new Vector3(forward.x, 0, forward.z);
        Quaternion targetQuaternion = Quaternion.LookRotation(forward, Vector3.up);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, targetQuaternion, Time.deltaTime * smooth);
        enemy.Translate(Vector3.forward * Time.deltaTime * smooth);
        if (Vector3.Distance(enemy.position, pathsList[index].position) < 2f)
        {
            index++;
            index %= pathsList.Count;
        }
    }

    public override void Reason()
    {
        if (Vector3.Distance(enemy.position, player.position) < 4)
        {
            fsm.PerformTransition(Transition.FindPlayer);
        }
    }
}
