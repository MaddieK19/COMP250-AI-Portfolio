using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

    public GameObject boid;
    public Vector3 flockCenter;
    static int maxBoids = 5;
    public GameObject[] boids = new GameObject[maxBoids];

    // Use this for initialization
    void Start () {
		for (int i = 0; i < maxBoids; i++)
        {
            Vector3 boidPosition = new Vector3(i, Random.Range(1, 20), Random.Range(1, 5));
            boids[i] = Instantiate(boid, boidPosition, Quaternion.identity) as GameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
