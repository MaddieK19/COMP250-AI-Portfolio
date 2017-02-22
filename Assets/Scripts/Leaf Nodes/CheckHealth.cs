using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckHealth : ActionNode
{
    public Fish fish;
    public int healthThreshold;
    public override Status Update()
    {
        if (fish.getHealth() < healthThreshold)
        {
            return Status.Running;
        }
        else
            return Status.Failure;
    }
}
