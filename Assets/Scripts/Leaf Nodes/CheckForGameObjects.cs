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
    //! The GameObject whose distance is being checked
    GameObject objectToCheck;
    //! Float for how far apart the two GameObjects are
    float distance; 
    //! float for how close together objects need to be to return success
    public float distanceThreshold;
    //! Updates the node and returns a Status
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
