using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that checks the boids health
 */
public class CheckHealth : ActionNode
{
    //! Boid component of boid prefab
    Boid boid;
    //! Int for the minimum and maixmum health values to be checked
    public int minHealth, maxHealth;

    //! Updates the node and returns a Status
    public override Status Update()
    {
        boid = self.GetComponent<Boid>();

        if (minHealth > boid.getHealth() && boid.getHealth() < maxHealth)
        {
            return Status.Running;
        }
        else
            return Status.Failure;
    }
}
