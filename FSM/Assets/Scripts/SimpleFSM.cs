using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle,//空闲状态
    Patrol,//巡逻状态
    Chase,//追逐状态
    Attack//攻击状态
}

/// <summary>
///switch语句实现简单有限状态机 
/// </summary>
public class SimpleFSM : MonoBehaviour
{
    private States currentState = States.Idle;
    private void Update()
    {
        switch (currentState) 
        {
            case States.Idle:
                //TODO 空闲状态动作
                break;
            case States.Patrol:
                //TODO 巡逻状态动作
                break;
            case States.Chase:
                //TODO 追逐状态动作
                break;
            case States.Attack:
                //TODO 攻击状态动作
                break;
        }
    }
}
