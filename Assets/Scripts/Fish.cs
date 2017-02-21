using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Fish class  
 */
public class Fish : MonoBehaviour {
    public enum CollisionStates
    {
        None,
        Player,
        OtherFish,
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
        else
            collisionState = CollisionStates.None;
    }
}
