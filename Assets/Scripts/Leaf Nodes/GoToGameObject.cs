using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using UnityEngine.AI;

public class GoToGameObject : ActionNode
{

    public NavMeshAgent fishNavMesh;
    public GameObjectVar fish;
    public GameObjectVar goalObject;

    public override Status Update()
    {
        if (Vector3.Distance(fish.Value.transform.position, goalObject.Value.transform.position) < 1)
        {
            return Status.Success;
        }

        else
        {
            fishNavMesh.SetDestination(goalObject.Value.transform.position);
            return Status.Running;
        }
    }
}

 