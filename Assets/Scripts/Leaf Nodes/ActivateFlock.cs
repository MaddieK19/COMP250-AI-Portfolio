using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that changes the flockActive state to true
 */


public class ActivateFlock : ActionNode
{
    //! The BoidController that manages the boids behaviour
    public BoidController controller;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        controller.flockActive = true;
        return Status.Success;
    }
}
