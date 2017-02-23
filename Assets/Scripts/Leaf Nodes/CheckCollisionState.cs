using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckCollisionState : ActionNode
{
    // Fish to see if fish has collided with anything
    public Boid boid;
    // String to check the name of what fish has collided with
    public String collidedWith;

    public override Status Update()
    {
        if (collidedWith == null)
            return Status.Failure;
        else if (collidedWith == "Player" && boid.collisionState == Boid.CollisionStates.Player)
            return Status.Success;
        else if (collidedWith == "Predator" && boid.collisionState == Boid.CollisionStates.Predator)
            return Status.Success;
        else
            return Status.Failure;

    }
}
