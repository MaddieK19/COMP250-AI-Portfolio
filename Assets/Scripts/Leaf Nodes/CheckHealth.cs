﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class CheckHealth : ActionNode
{
    Boid boid;
    public int minHealth, maxHealth;
    public override Status Update()
    {
        boid = self.GetComponent<Boid>();

        if (minHealth > boid.getHealth() && boid.getHealth() < maxHealth)
        {
            return Status.Running;
        }
        else
            return Status.Failure;
    }
}
