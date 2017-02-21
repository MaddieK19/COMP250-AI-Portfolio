using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckForInput : ActionNode
{
    // Action node for checking for player input
    public StringVar key;
    public override Status Update()
    {
        if (Input.GetKeyDown(key))
            return Status.Success;
        else
            return Status.Failure;
    }
}
