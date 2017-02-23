using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class ResetCollisionState : ActionNode
{
    // Boid to see if fish has collided with anything
    public Boid boid;

    public override Status Update()
    {
        boid.collisionState = Boid.CollisionStates.None;
        return Status.Success;
    }
}
