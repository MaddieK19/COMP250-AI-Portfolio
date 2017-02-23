using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class IdleMove : ActionNode
{
    public Boid boid;

    public override Status Update()
    {
       // boid.circularMovement();

        if (boid.collisionState != Boid.CollisionStates.None)
            return Status.Failure;
        else 
            return Status.Success;
    }
}
