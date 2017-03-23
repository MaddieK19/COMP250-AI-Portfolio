using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using UnityEngine.AI;

public class GoToGameObject : ActionNode
{
    public GameObject goalObject;

    public override Status Update()
    {
        if (goalObject == null)
        {
            goalObject = self;
        }

        if (Vector3.Distance(self.transform.position, goalObject.transform.position) < 1)
        {
            return Status.Success;
        }

        else
        {
            self.transform.position = Vector3.MoveTowards(self.transform.position, goalObject.transform.position, Time.deltaTime);
            return Status.Running;
        }
    }
}

 