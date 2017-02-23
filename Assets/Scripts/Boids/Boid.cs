using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boid : MonoBehaviour {
    // Vector3 for the boid velocity
    public Vector3 velocity;

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
		
	}

    void OnCollisionEnter(Collision col)
    {
        //if (col.gameObject.tag == "Player")
        //   collisionState = CollisionStates.Player;
        if (col.gameObject.tag == "Fish")
            collisionState = CollisionStates.OtherFish;
        else if (col.gameObject.tag == "Predator")
            collisionState = CollisionStates.Predator;
        else
            collisionState = CollisionStates.None;
    }
}
