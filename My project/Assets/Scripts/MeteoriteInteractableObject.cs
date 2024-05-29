using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteInteractable : PlayerInteractableObjects
{
    public float speed = 5f;
    public float horizontalSpeed;
    public float rotationSpeed = 100f;
    private float horizontalDirection;
    void Start()
    {
        horizontalSpeed = Random.Range(1f, 4f);
        horizontalDirection = Random.Range(0, 2) == 0 ? -1 : 1;
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
        //player.TakeDamage(10); if needed

        if (other is BulletInteractableObject) //maybe delete this since this interaction is defined in bullet, may add other types.
        {
            BulletInteractableObject bullet = other as BulletInteractableObject;
            //InteractWithMeteorite(meteorite);
        }
        else if (other is PowerUp)
        {
            PowerUp powerUp = other as PowerUp;
            //InteractWithPowerUp(powerUp);
        }

        Destroy(gameObject);
    }
}


