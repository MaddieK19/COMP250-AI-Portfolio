using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeadNode that calls chooseFleeDirection in a BoidController
 */


public class GenerateRunAwayDirections : ActionNode
{
    //! BoidController of the boids that need to flee
    public BoidController controller;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        controller.chooseAllFleeDirections();
        return Status.Success;
    }
}
