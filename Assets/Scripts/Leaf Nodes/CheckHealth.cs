using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckHealth : ActionNode
{
    public Fish fish;
    public int minHealth, maxHealth;
    public override Status Update()
    {
        if (minHealth > fish.getHealth() && fish.getHealth() < maxHealth)
        {
            return Status.Running;
        }
        else
            return Status.Failure;
    }
}
