using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : PlayerInteractableObjects
{
    public float speed = 5f;
    public float horizontalSpeed;
    public float rotationSpeed = 100f;
    private float horizontalDirection;
    public Rigidbody rigidbody;

    void Start()
    {
        // Set a random horizontal direction (-1 for left, 1 for right)
        horizontalSpeed = Random.Range(1f,4f);
        horizontalDirection = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    void Update()
    {
        // Move the meteorite downward
        transform.position += Vector3.down * speed * Time.deltaTime;
        
        // Move the meteorite horizontally
        transform.position += Vector3.right * horizontalDirection * horizontalSpeed * Time.deltaTime;

        // Rotate the meteorite around its Z axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        if (transform.position.x <= -2 || transform.position.x >= 2) {
            horizontalDirection *= -1;
        }
    }

    void OnBecameInvisible()
    {
        // Destroy the meteorite when it goes off-screen
        Destroy(gameObject);
    }
}


