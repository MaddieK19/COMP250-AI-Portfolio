﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Boid controller class that manages boids and their behaviour/movement
 * Used pseudocode from http://www.kfish.org/boids/pseudocode.html as a starting point
 */

public class BoidController : MonoBehaviour
{
    //public GameObject flock;
    // boid prefab
    public GameObject boidPrefab;

    public GameObject pond;

    // Vec3 for the center of the flocking
    public Vector3 flockCenter;
    //Vector 3 used to determine boids next position 
    Vector3 cohesionVector, separationVector;

    // int for the maximum number of boids that will be spawned
    static int maxBoids = 100;

    // float for the boids movement speed
    float speed = 0.6f;

    float timeCounter = 0;

    float seperationDistance = 0.5f, cohesionAmount = 100;

    Bounds waterBounds;

    //! Array of boid prefabs
    public GameObject[] boids; 
    //! Bool for whether the boids should flock be flocking
    public bool flockActive = false;

    // Use this for initialization
    void Start()
    {
        waterBounds = pond.GetComponent<Collider>().bounds;
        boids = new GameObject[maxBoids];
        // Fills the boids array with boid prefabs
        for (int i = 0; i < maxBoids; i++)
        {
            Vector3 boidPosition = new Vector3(Random.Range(waterBounds.min.x, waterBounds.max.x), 
                Random.Range(waterBounds.min.y, waterBounds.max.y), 
                Random.Range(waterBounds.min.z, waterBounds.max.z));
            boids[i] = Instantiate(boidPrefab, boidPosition, Quaternion.identity) as GameObject;
        }
        chooseFleeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (flockActive)
            updateFlock();
        else
            fleeFromDanger();
    }

    public void updateFlock()
    {
        calculateCenter();
        waterBounds = pond.GetComponent<Collider>().bounds;
        updateBoidPosition();
        circularMovement();
    }

    // Recalculates each boids position
    void updateBoidPosition()
    {
        transform.position = clampPosition(transform.position);
        for (int i = 0; i < maxBoids; i++)
        {
            cohesion(boids[i]);
            seperate(boids[i]);

            Boid currentBoid = boids[i].GetComponent<Boid>();
            
            currentBoid.velocity = currentBoid.velocity + cohesionVector + separationVector; ;
            
            

            if (!checkInWater(boids[i]))
            {
                boids[i].transform.position = clampPosition(boids[i].transform.position);
                currentBoid.velocity = -currentBoid.velocity;
            }

            currentBoid.capVelocity();
            boids[i].transform.position = boids[i].transform.position + currentBoid.velocity * Time.deltaTime * speed;
        }
    }

    bool checkInWater(GameObject boid)
    {
        return boid.GetComponent<Collider>().bounds.Intersects(waterBounds);
    }

    // Applies cohesion rule to vector
    void cohesion(GameObject boid)
    {
        if (boid.transform.position != transform.position)
            cohesionVector = (transform.position - boid.transform.position) / cohesionAmount;
    }

    // Stops boids from colliding and makes them match velocites 
    void seperate(GameObject boid)
    {
        Vector3 center = new Vector3();
        for (int i = 0; i < maxBoids; i++)
        {
            if (boids[i] != boid)
            {
                if (Vector3.Distance(boids[i].transform.position, boid.transform.position) < seperationDistance)
                {
                    center = center - (boids[i].transform.position - boid.transform.position);
                    boid.GetComponent<Boid>().velocity = (boid.GetComponent<Boid>().velocity + boids[i].GetComponent<Boid>().velocity) / 2;
                    boids[i].GetComponent<Boid>().velocity = boid.GetComponent<Boid>().velocity;
                }
            }
        }

        separationVector = center;
    }

    // Calculates and returns the center points of all the boids
    void calculateCenter()
    {
        // Resets center to 0
        Vector3 flockCenter = new Vector3();
        for (int i = 0; i < maxBoids; i++)
        {
            flockCenter = flockCenter + boids[i].transform.position;
        }
        flockCenter = transform.position / maxBoids;
    }

    void fleeFromDanger()
    {
        for (int i = 0; i < maxBoids; i++)
        {
            boids[i].transform.position = 
                Vector3.MoveTowards(boids[i].transform.position, boids[i].GetComponent<Boid>().runDirection, Time.deltaTime);
        }

    }

    public void chooseFleeDirection()
    {
        for (int i = 0; i < maxBoids; i++)
        {
            boids[i].GetComponent<Boid>().chooseRunDirection();
            boids[i].GetComponent<Boid>().runDirection = clampPosition(boids[i].GetComponent<Boid>().runDirection);
        }

    }

    void moveFlock(Vector3 goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, speed * Time.deltaTime);
    }

    // Moves the center of the flock in a circle for the boids to follow
    void circularMovement()
    {
        Vector3 previousPosition = transform.position;
        timeCounter += Time.deltaTime;
        transform.position = new Vector3(Mathf.Cos(timeCounter) * 2, Mathf.Sin(timeCounter) * 2, 0);
    }

    Vector3 clampPosition(Vector3 objectPosition)
    {
        objectPosition.x = Mathf.Clamp(objectPosition.x, waterBounds.min.x, waterBounds.max.x);
        objectPosition.y = Mathf.Clamp(objectPosition.y, waterBounds.min.y, waterBounds.max.y);
        objectPosition.z = Mathf.Clamp(objectPosition.z, waterBounds.min.z, waterBounds.max.z);
        return objectPosition;
    }
}
