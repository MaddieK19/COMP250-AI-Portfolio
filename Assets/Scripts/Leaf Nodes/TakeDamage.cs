using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;


public class TakeDamage : ActionNode
{
    public Fish fish;
    public override Status Update()
    {
        if (fish.getHealth() < 1)
            return Status.Failure;
        else
        {
            int randomDamage = UnityEngine.Random.Range(0, 51);
            fish.setHealth(fish.getHealth() - 50 - randomDamage);
            return Status.Success;
        }
            
    }
}
