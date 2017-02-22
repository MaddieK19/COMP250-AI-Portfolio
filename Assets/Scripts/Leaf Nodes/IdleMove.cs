using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class IdleMove : ActionNode
{
    public Fish fish;

    public override Status Update()
    {
        fish.circularMovement();

        if (fish.collisionState != Fish.CollisionStates.None)
            return Status.Failure;
        else 
            return Status.Success;
    }
}
