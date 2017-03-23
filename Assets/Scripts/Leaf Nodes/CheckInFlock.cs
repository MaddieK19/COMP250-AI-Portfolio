using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that returns Success if the boid is currently flocking
 */

public class CheckInFlock : ActionNode
{
    public override Status Update()
    {
        Boid boid = self.GetComponent<Boid>();

        if (boid.inFlock == true)
            return Status.Running;
        else
            return Status.Failure;
    }
}
