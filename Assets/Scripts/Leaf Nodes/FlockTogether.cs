using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class FlockTogether : ActionNode
{
    public BoidController controller;

    public override Status Update()
    {
        controller.flockActive = false;
        return Status.Success;
    }
}
