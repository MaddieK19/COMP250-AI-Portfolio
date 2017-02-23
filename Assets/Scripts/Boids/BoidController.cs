using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Using pseudocode from http://www.kfish.org/boids/pseudocode.html
 */

public class BoidController : MonoBehaviour {
    // boid prefab
    public GameObject boid;
    // Vec3 for the center of the flocking
    public Vector3 flockCenter = new Vector3(0,0,0);
    // the maximum number of boids that will be spawned
    static int maxBoids = 5;
    //! int for the range of coordinates where boids can spawn
    int spawnArea = 3;
    // float for the boids movement speed
    float speed = 0.6f;
    //! Array of boid prefabs
    public GameObject[] boids = new GameObject[maxBoids];


    //Vector 3 used to determine boids next position 
    Vector3 alignmentVector, cohesionVector, separationVector;


    // Use this for initialization
    void Start () {
        // Fills the boids array with boid prefabs
		for (int i = 0; i < maxBoids; i++)
        {
            Vector3 boidPosition = new Vector3(Random.Range(-spawnArea, spawnArea), Random.Range(-spawnArea, spawnArea), Random.Range(-spawnArea, spawnArea));
            boids[i] = Instantiate(boid, boidPosition, Quaternion.identity) as GameObject;
        }
        calculateCenter();
    }
	
	// Update is called once per frame
	void Update () {
       for (int i = 0; i < maxBoids; i++)
        {
           
            align(boids[i]);


            boids[i].GetComponent<Boid>().velocity = boids[i].GetComponent<Boid>().velocity +  alignmentVector;
            boids[i].transform.position = boids[i].transform.position + boids[i].GetComponent<Boid>().velocity;
            
            //boids[i].transform.Translate(0, 0, Time.deltaTime * speed);
            //boids[i].transform.position = Vector3.MoveTowards(boids[i].transform.position, move.transform.position, speed * Time.deltaTime);
        }

    }

    // Applies alignment rules to vector
    void align(GameObject boid)
    {
        calculateCenter();
        if (boid.transform.position != flockCenter)
            alignmentVector = (flockCenter - boid.transform.position) / 100;
        
    }
    // Applies cohesion rules to vector
    Vector3 cohesion()
    {
        return new Vector3();
    }
    // Applies seperate rules to vector
    Vector3 seperate()
    {
        return new Vector3();
    }

    // Calculates and returns the center points of all the boids
    void  calculateCenter()
    {
        // Resets center to 0
        flockCenter = new Vector3();
        for (int i = 0; i < maxBoids; i++)
        {
            flockCenter = flockCenter + boids[i].transform.position;
        }

        flockCenter = flockCenter / maxBoids;
    }
}
