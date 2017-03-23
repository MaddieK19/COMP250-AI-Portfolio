using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that checks to see if two objects are intersecting
 */
public class CheckForIntersect : ActionNode {
    //! GameObject that being checked against
    GameObject objectToCheck;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        objectToCheck = GameObject.FindGameObjectWithTag("Predator");

        if (self.GetComponent<Collider>().bounds.Intersects(objectToCheck.GetComponent<Collider>().bounds))
            return Status.Success;
        else
            return Status.Failure;

    }
}
