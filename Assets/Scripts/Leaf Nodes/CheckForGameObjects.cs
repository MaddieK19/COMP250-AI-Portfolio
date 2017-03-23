using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that check the distance between two objects
 * and returns Success if it's under the threshold
 */
public class CheckForGameObjects : ActionNode
{
    //
    GameObject objectToCheck;
    FloatVar distance;
    //! float 
    public float distanceThreshold;
    public override Status Update()
    {
        if (objectToCheck == null)
            objectToCheck = GameObject.FindWithTag("Predator");

        
        distance = (objectToCheck.transform.position - self.transform.position).magnitude;

        if (distance > distanceThreshold)
            return Status.Failure;
        else
            return Status.Success;
    }
}
