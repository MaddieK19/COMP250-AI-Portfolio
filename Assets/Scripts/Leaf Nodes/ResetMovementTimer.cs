using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class ResetMovementTimer : ActionNode
{
    // Fish to see if fish has collided with anything
    public Fish fish;

    public override Status Update()
    {
        fish.resetMovementTimer();
        return Status.Success;
    }
}
