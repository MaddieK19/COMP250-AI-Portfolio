using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that take a random amount of health from a boid
 */

public class TakeDamage : ActionNode
{
    //! Boid component of boid prefab
    Boid boid;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        if (boid == null)
            boid = self.GetComponent<Boid>();

        if (boid.getHealth() < 1)
            return Status.Failure;
        else
        {
            int damage = boid.getHealth() - 50 - UnityEngine.Random.Range(0, 51);
            if (damage < 0)
                damage = 0;
            boid.setHealth(damage);
            return Status.Success;
        }
            
    }
}
