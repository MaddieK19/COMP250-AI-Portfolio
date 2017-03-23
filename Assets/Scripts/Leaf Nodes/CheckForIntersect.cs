using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckForIntersect : ActionNode {
    GameObject predator;

    public override Status Update()
    {
        predator = GameObject.FindGameObjectWithTag("Predator");

        if (self.GetComponent<Collider>().bounds.Intersects(predator.GetComponent<Collider>().bounds))
            return Status.Success;
        else
            return Status.Failure;

    }
}
