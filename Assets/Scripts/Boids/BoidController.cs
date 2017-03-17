using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Boid controller class that manages boids and their behaviour/movement
 * Used pseudocode from http://www.kfish.org/boids/pseudocode.html as a starting point
 */

public class BoidController : MonoBehaviour
{
    // Flock object to move the flock center
    public GameObject flock;
    // Boid prefab to make flock
    public GameObject boidPrefab;

    public Boid boidComponent;
    // Pond object 
    public GameObject pond;
    // Bounds for where the boids can move
    Bounds waterBounds;

    // Vec3 for the center of the flocking
    public Vector3 flockCenter;
    // Vec3 for the flock velocity
    public Vector3 flockVelocity = new Vector3(1, 0, 0);
    //Vector 3 used to determine boids next position 
    Vector3 cohesionVector, separationVector;

    // int for the maximum number of boids that will be spawned
    static int maxBoids = 100;
    //! int for the range of coordinates where boids can spawn
    static int spawnArea = 5;
    // float for the boids movement speed
    float speed = 0.6f;
    // timer for updating flock position
    float timeCounter = 0;

    float seperationDistance = 0.5f, cohesionAmount = 100;

    //! Array of boid prefabs
    public GameObject[] boids;
    //! Bool for whether the boids should flock be flocking
    public bool flockActive = false;

    // Use this for initialization
    void Start()
    {
        // Sets collider bounds for the flock
        waterBounds = pond.GetComponent<Collider>().bounds;

        boids = new GameObject[maxBoids];
        // Fills the boids array with boid prefabs
        for (int i = 0; i < maxBoids; i++)
        {
            Vector3 boidPosition = new Vector3(Random.Range(-spawnArea, spawnArea), Random.Range(0, spawnArea), Random.Range(-spawnArea, spawnArea));
            boids[i] = Instantiate(boidPrefab, boidPosition, Quaternion.identity) as GameObject;
        }
        chooseFleeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        calculateCenter();

        if (flockActive)
            updateFlock();
        else
            fleeFromDanger();
    }

    public void updateFlock()
    {
        updateBoidPosition();
        circularMovement();
    }

    // Recalculates each boids position
    void updateBoidPosition()
    {
        clampPosition(flock.transform.position);

        for (int i = 0; i < maxBoids; i++)
        {
            cohesion(boids[i]);
            seperate(boids[i]);

            boidComponent = boids[i].GetComponent<Boid>();

            Vector3 boidVelocity = boids[i].GetComponent<Boid>().velocity + cohesionVector + separationVector;
            boidComponent.velocity = boidVelocity;
            boidComponent.capVelocity();
            boids[i].transform.position = boids[i].transform.position + boidComponent.velocity * Time.deltaTime * speed;

            if (!checkInWater(boids[i]))
            {
                clampPosition(boids[i].transform.position);

                if (boidComponent.velocity.y < waterBounds.center.y - waterBounds.extents.y ||
                    boidComponent.velocity.y > waterBounds.center.y + waterBounds.extents.y)
                {
                    boids[i].GetComponent<Boid>().velocity.y = -boidComponent.velocity.y;
                }
                if (boidComponent.velocity.x < waterBounds.center.x - waterBounds.extents.x ||
                    boidComponent.velocity.x > waterBounds.center.x + waterBounds.extents.x)
                {
                    boids[i].GetComponent<Boid>().velocity.x = -boidComponent.velocity.x;
                }
                if (boidComponent.velocity.z < waterBounds.center.z - waterBounds.extents.z ||
                    boidComponent.velocity.z > waterBounds.center.z + waterBounds.extents.z)
                {
                    boids[i].GetComponent<Boid>().velocity.z = -boidComponent.velocity.z;
                }
            }
        }
    }

    // Applies cohesion rule to vector
    void cohesion(GameObject boid)
    {
        if (boid.transform.position != flock.transform.position)
            cohesionVector = (flock.transform.position - boid.transform.position) / cohesionAmount;
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
        flockCenter = flock.transform.position / maxBoids;
    }

    void fleeFromDanger()
    {
        for (int i = 0; i < maxBoids; i++)
        {
            if (!checkInWater(boids[i]))
            {
                boids[i].GetComponent<Boid>().runDirection = -boids[i].GetComponent<Boid>().runDirection;
            }
            boids[i].transform.position =
                Vector3.MoveTowards(boids[i].transform.position, boids[i].GetComponent<Boid>().runDirection, Time.deltaTime);
        }
    }
    
    public void chooseFleeDirection()
    {
        for (int i = 0; i < maxBoids; i++)
        {
            boids[i].GetComponent<Boid>().chooseRunDirection();
            //boids[i].GetComponent<Boid>().runDirection = clampPosition(boids[i].GetComponent<Boid>().runDirection);
        }

    }

    // Moves flock towards goal
    void moveFlock(Vector3 goal)
    {
        flock.transform.position = Vector3.MoveTowards(flock.transform.position, goal, speed * Time.deltaTime);
    }

    // Moves the center of the flock in a circle for the boids to follow
    void circularMovement()
    {
        Vector3 previousPosition = flock.transform.position;
        timeCounter += Time.deltaTime;
        flock.transform.position = new Vector3(Mathf.Cos(timeCounter) * 2, Mathf.Sin(timeCounter) * 2, 0);
    }

    // Prevents boids from leaving an bounded area
    Vector3 clampPosition(Vector3 gamePos)
    { 
        gamePos.x = Mathf.Clamp(gamePos.x, waterBounds.center.x - waterBounds.extents.x, waterBounds.center.x + waterBounds.extents.x);
        gamePos.y = Mathf.Clamp(gamePos.y, waterBounds.center.y - waterBounds.extents.y, waterBounds.center.y + waterBounds.extents.y);
        gamePos.z = Mathf.Clamp(gamePos.z, waterBounds.center.z - waterBounds.extents.z, waterBounds.center.z + waterBounds.extents.z);

        return gamePos;
    }

    bool checkInWater(GameObject boid)
    {
        return boid.GetComponent<Collider>().bounds.Intersects(waterBounds);
    }
}