using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckForGameObjects : ActionNode
{
    public GameObjectVar objectToCheck;
    public GameObjectVar fish;
    FloatVar distance;
    public FloatVar distanceThreshold;
    public override Status Update()
    {
        distance = (objectToCheck.Value.transform.position - fish.Value.transform.position).magnitude;

        if (distance > distanceThreshold)
            return Status.Failure;
        else
            return Status.Success;
    }
}
