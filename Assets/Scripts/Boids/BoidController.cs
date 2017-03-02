using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  Using pseudocode from http://www.kfish.org/boids/pseudocode.html
 */

public class BoidController : MonoBehaviour
{
    public GameObject flock;
    // boid prefab
    public GameObject boid;
    // Vec3 for the center of the flocking
    public Vector3 flockCenter = new Vector3(0, 0, 0);
    // the maximum number of boids that will be spawned
    static int maxBoids = 7;
    //! int for the range of coordinates where boids can spawn
    int spawnArea = 2;
    // float for the boids movement speed
    float speed = 0.6f;
    float seperationDistance = 0.5f, cohesionAmount = 100;
    //! Array of boid prefabs
    public GameObject[] boids; 
    

    //Vector 3 used to determine boids next position 
    Vector3 alignmentVector, cohesionVector, separationVector;


    // Use this for initialization
    void Start()
    {
        boids = new GameObject[maxBoids];
        // Fills the boids array with boid prefabs
        for (int i = 0; i < maxBoids; i++)
        {
            Vector3 boidPosition = new Vector3(Random.Range(-spawnArea, spawnArea), Random.Range(-spawnArea, spawnArea), Random.Range(-spawnArea, spawnArea));
            boids[i] = Instantiate(boid, boidPosition, Quaternion.identity) as GameObject;
        }
        flockCenter = flock.transform.position;
        //calculateCenter();
    }

    // Update is called once per frame
    void Update()
    {
        //calculateCenter();
        
        for (int i = 0; i < maxBoids; i++)
        {
            cohesion(boids[i]);
            seperate(boids[i]);
            //align(boids[i]);


            Vector3 boidVelocity = boids[i].GetComponent<Boid>().velocity + cohesionVector + separationVector;// + alignmentVector;
            boids[i].GetComponent<Boid>().velocity = boidVelocity;
            boids[i].transform.position = boids[i].transform.position + boids[i].GetComponent<Boid>().velocity * Time.deltaTime * speed;

            //boids[i].transform.Translate(0, 0, Time.deltaTime * speed);
            //boids[i].transform.position = Vector3.MoveTowards(boids[i].transform.position, move.transform.position, speed * Time.deltaTime);
        }

    }

    // Applies cohesion rule to vector
    void cohesion(GameObject boid)
    {
        if (boid.transform.position != flockCenter)
            cohesionVector = (flockCenter - boid.transform.position) / cohesionAmount;
    }

    // Applies seperate rules to vector
    void seperate(GameObject boid)
    {
        flockCenter = new Vector3();
        for (int i = 0; i < maxBoids; i++)
        {
            if (boids[i] != boid)
            {
                if (Vector3.Distance(boids[i].transform.position, boid.transform.position) < seperationDistance)
                {
                    flockCenter = flockCenter - (boids[i].transform.position - boid.transform.position);

                    boid.GetComponent<Boid>().velocity = (boid.GetComponent<Boid>().velocity + boids[i].GetComponent<Boid>().velocity) / 2;
                    boids[i].GetComponent<Boid>().velocity = boid.GetComponent<Boid>().velocity;
                }
            }
        }

        separationVector = flockCenter;
        flockCenter = new Vector3();
    }

    // Applies alignment rules to vector
    void align(GameObject boid)
    {
        /*Vector3 boidVelocity = new Vector3(); // = boid.GetComponent<Boid>().velocity;

        for (int i = 0; i < maxBoids; i++)
        {
                boidVelocity = boidVelocity + boids[i].GetComponent<Boid>().velocity;
        }
        //boidVelocity = boidVelocity / (maxBoids - 1);
        alignmentVector = boidVelocity / 8;*/


    }



    // Calculates and returns the center points of all the boids
    void calculateCenter()
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
