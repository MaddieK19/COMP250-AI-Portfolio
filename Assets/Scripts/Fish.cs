using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Fish class  
 */
public class Fish : MonoBehaviour {
    private int health = 100;

    public int getHealth()
    {
        return health;
    }


    public void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public enum CollisionStates
    {
        None,
        Player,
        OtherFish,
        Predator,
        Environment
    };
    public CollisionStates collisionState;

    // Use this for initialization
    void Start () {
        collisionState = CollisionStates.None;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            collisionState = CollisionStates.Player;
        else if (col.gameObject.tag == "Fish")
            collisionState = CollisionStates.OtherFish;
        else if (col.gameObject.tag == "Predator")
            collisionState = CollisionStates.Predator;
        else
            collisionState = CollisionStates.None;
    }

    void takeDamage()
    {

    }
}
