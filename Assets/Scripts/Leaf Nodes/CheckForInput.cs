using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
/*!
 * LeafNode that checks to see if the player has pressed the specified key
 */
 
public class CheckForInput : ActionNode
{
    //! String for the key being checked
    public StringVar key;
    //! Updates the node and returns a Status
    public override Status Update()
    {
        if (Input.GetKeyDown(key))
            return Status.Success;
        else
            return Status.Failure;
    }
}
