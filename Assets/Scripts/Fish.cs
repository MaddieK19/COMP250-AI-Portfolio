using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Fish class  
 */
public class Fish : MonoBehaviour {
    // int for the fishes health level
    private int health = 100;

    // Variables to be used for moving in a circle
    public float yPos;
    Vector3 currentPosition;
    float timeCounter = 0;
    float x, y, z;

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
        //if (col.gameObject.tag == "Player")
         //   collisionState = CollisionStates.Player;
        if (col.gameObject.tag == "Fish")
            collisionState = CollisionStates.OtherFish;
        else if (col.gameObject.tag == "Predator")
            collisionState = CollisionStates.Predator;
        else
            collisionState = CollisionStates.None;
    }

    public void circularMovement()
    {
        Vector3 previousPosition = currentPosition;
        timeCounter += Time.deltaTime;
        x = Mathf.Cos(timeCounter) * 2;
        z = Mathf.Sin(timeCounter) * 2;
        y = yPos;
        currentPosition = new Vector3(x, y, z);
        transform.position = currentPosition;
    }

    public void resetMovementTimer()
    {
        timeCounter = 0;
    }
}
