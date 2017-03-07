using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class GenerateRunAwayDirections : ActionNode
{
    public BoidController controller;
    public override Status Update()
    {
        controller.chooseFleeDirection();
        return Status.Success;
    }
}
