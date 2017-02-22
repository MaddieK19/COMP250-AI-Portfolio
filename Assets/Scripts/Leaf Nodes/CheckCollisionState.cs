using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckCollisionState : ActionNode
{
    // Fish to see if fish has collided with anything
    public Fish fish;
    // String to check the name of what fish has collided with
    public String collidedWith;

    public override Status Update()
    {
        if (collidedWith == null)
            return Status.Failure;
        else if (collidedWith == "Player" && fish.collisionState == Fish.CollisionStates.Player)
            return Status.Success;
        else if (collidedWith == "Predator" && fish.collisionState == Fish.CollisionStates.Predator)
            return Status.Success;
        else
            return Status.Failure;

    }
}
