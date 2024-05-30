using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteInteractable : PlayerInteractableObjects
{
    public float speed = 5f;
    public float horizontalSpeed;
    public float rotationSpeed = 100f;
    private float horizontalDirection;
    public GameObject impactPrefab;
    public GameObject fireVFXPrefab; 
    private GameObject fireVFX; // Store reference to the instantiated fire VFX

    void Start()
    {
        horizontalSpeed = Random.Range(1f, 4f);
        horizontalDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        if (!GetComponent<Collider2D>())
        {
            gameObject.AddComponent<CircleCollider2D>().isTrigger = true; // Add a CircleCollider2D if not present
        }

        // Instantiate the fire VFX and make it a child of the meteorite
        fireVFX = Instantiate(fireVFXPrefab, transform.position, Quaternion.identity, transform);
        fireVFX.transform.localPosition = Vector3.zero; // Ensure the fire VFX is centered on the meteorite
    }

    void Update()
    {
        Move();

        if (transform.position.x <= -2 || transform.position.x >= 2)
        {
            horizontalDirection *= -1;
        }
    }

    protected override void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.position += Vector3.right * horizontalDirection * horizontalSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public override void InteractWithOtherInteractable(PlayerInteractableObjects other)
    {
        if (other is BulletInteractableObject)
        {
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }       
    }
}
