using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLight : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the movement
    public float maxDistance = 3.0f; // Maximum distance to move in either direction

    private Vector3 initialPosition; // Initial position of the object

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new x position
        float newX = initialPosition.x + Mathf.PingPong(Time.time * speed, maxDistance * 2) - maxDistance;

        // Update the position
        transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
    }
}