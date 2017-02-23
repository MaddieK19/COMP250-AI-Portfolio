using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;


public class TakeDamage : ActionNode
{
    public Boid boid;
    public override Status Update()
    {
        if (boid.getHealth() < 1)
            return Status.Failure;
        else
        {
            int randomDamage = UnityEngine.Random.Range(0, 51);
            boid.setHealth(boid.getHealth() - 50 - randomDamage);
            return Status.Success;
        }
            
    }
}
