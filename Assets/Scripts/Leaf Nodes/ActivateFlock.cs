﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class ActivateFlock : ActionNode
{
    public BoidController controller;

    public override Status Update()
    {
        controller.flockActive = true;
        return Status.Success;
    }
}