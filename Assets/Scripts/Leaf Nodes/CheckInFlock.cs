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
    //! Boid script component in a boid prefab
    Boid boid;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        boid = self.GetComponent<Boid>();

        if (boid.inFlock == true)
            return Status.Running;
        else
            return Status.Failure;
    }
}
