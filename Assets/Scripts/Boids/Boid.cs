﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boid : MonoBehaviour {
    // Vector3 for the boid velocity
    public Vector3 velocity = new Vector3(0.0f,0.0f,0.0f);
    public Vector3 runDirection;
    // int for capping Velocity so boids dont move too fast 
    public int velocityCap = 2;

    // int for the fishes health level
    private int health = 100;

    // Enum of possible collision statuses for the boid
    public enum CollisionStates
    {
        None,
        Player,
        OtherFish,
        Predator,
        Environment
    };
    // The boid current collision status
    public CollisionStates collisionState;

    // returns the boids health 
    public int getHealth()
    {
        return health;
    }

    // sets the boids health
    public void setHealth(int newHealth)
    {
        health = newHealth;
    }

    // Use this for initialization
    void Start () {
        collisionState = CollisionStates.None;
    }
	
	// Update is called once per frame
	void Update () {
        //capVelocity();		
	}

    // Setes the boids collision state to allow it to react correctly
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            collisionState = CollisionStates.Player;
            Vector3.MoveTowards(transform.position, -col.transform.position, Time.deltaTime);
        }
           
        else if (col.gameObject.tag == "Predator")
            collisionState = CollisionStates.Predator;
        else
            collisionState = CollisionStates.None;
    }

    //Generates a Vec3 of random coordinates
    public void chooseRunDirection()
    {
        runDirection = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }

    public void capVelocity()
    {
        Vector3 currentVelocity = transform.position;
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -velocityCap, velocityCap);
        currentVelocity.y = Mathf.Clamp(currentVelocity.y, -velocityCap, velocityCap);
        currentVelocity.z = Mathf.Clamp(currentVelocity.z, -velocityCap, velocityCap);

    }
}
