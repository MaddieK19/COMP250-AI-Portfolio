using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that sets the flock state to inactive 
 */

public class DeactivateFlock : ActionNode
{
    //! BoidController that needs to be checked
    public BoidController controller;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        controller.flockActive = false;
        return Status.Success;
    }
}
