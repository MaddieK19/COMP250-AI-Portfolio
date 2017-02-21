using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimPath : MonoBehaviour {
    public float yPos;
    Vector3 currentPosition;
    float timeCounter = 0;
    float x, y, z;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 previousPosition = currentPosition;
        timeCounter += Time.deltaTime;
        x = Mathf.Cos(timeCounter) * 2;
        z = Mathf.Sin(timeCounter) * 2;
        y = yPos;
        currentPosition = new Vector3(x, y, z);
        transform.position = currentPosition;
    }

}
