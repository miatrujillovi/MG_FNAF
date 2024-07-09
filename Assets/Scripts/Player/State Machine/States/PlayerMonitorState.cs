using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonitorState : PlayerBaseState
{
    public override void OnEnter(PlayerStateMachine _machine)
    {
        Monitor.Instance.setIsActive(true);
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        Monitor.Instance.setIsActive(false);
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        
    }
} 
