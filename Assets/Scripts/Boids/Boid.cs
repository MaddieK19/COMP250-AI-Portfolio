using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*!
 * Boid class
 * Contains the the velocity and flee directions and
 * handles the boids collisions
 */

public class Boid : MonoBehaviour {
    //! Vector3 for the boid velocity
    public Vector3 velocity;
    //! Vector3 for the random direction the boid will move in when not flocking
    public Vector3 runDirection;
    //! int for capping Velocity so boids dont move too fast 
    public int velocityCap = 4;
    //! Bool for whether flocking is active
    public bool inFlock = false;

    //! int for the fishes health level
    public int health = 100;

    //! returns the boids health 
    public int getHealth()
    {
        return health;
    }

    //! sets the boids health
    public void setHealth(int newHealth)
    {
        health = newHealth;
    }

    //! Use this for initialization
    void Start () {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
	
	//! Update is called once per frame
	void Update () {
        
	}

    //! Generates a Vec3 of random coordinates
    public void chooseRunDirection()
    {
        runDirection = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }

    //! Clamps the boids velocity to stop it moving to fast
    public void clampVelocity()
    {
        velocity.x = Mathf.Clamp(velocity.x, -velocityCap, velocityCap);
        velocity.y = Mathf.Clamp(velocity.y, -velocityCap, velocityCap);
        velocity.z = Mathf.Clamp(velocity.z, -velocityCap, velocityCap);
    }
}
