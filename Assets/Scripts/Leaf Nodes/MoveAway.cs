using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;
using UnityEngine.AI;

public class MoveAway : ActionNode
{
    public NavMeshAgent fishNavMesh;
    public GameObjectVar fish;
    public GameObjectVar player;

    public override Status Update()
    {
        fish.transform.rotation = Quaternion.LookRotation(fish.transform.position - player.Value.transform.position);
        return Status.Success;
        /*
        if (fish.Value.transform.position == player.Value.transform.position)
            return Status.Success;
        else
        {
            fishNavMesh.SetDestination(player.Value.transform.position);
            return Status.Running;
        }*/
    }
}
