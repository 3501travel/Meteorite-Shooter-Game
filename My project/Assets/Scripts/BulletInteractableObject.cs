using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteractableObject : PlayerInteractableObjects
{
    public float speed = 10f;
    public Vector3 bulletDirection = Vector3.zero;
    private int bounceCount = 0;
    private const int MAX_BOUNCE_COUNT = 5;
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x <= -2 || transform.position.x >= 2)
        {
            bulletDirection.x *= -1;
            bounceCount++;
            
            // get symmetric of bullet 
            // similar to transform.Rotate(Vector3.forward, angle);
            // transform.Rotate(Vector3.forward, 180); //get the angle from bullet direction x and y
            float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            

            if(bounceCount >= MAX_BOUNCE_COUNT)
            {
                Destroy(gameObject);
                // play break animation
            }
        }
        Move();
    }

    protected override void Move()
    {
        transform.position += speed * Time.deltaTime * bulletDirection;
    }

    public void SetDirection(Vector3 direction)
    {
        bulletDirection = direction;
    }

    public override void InteractWithOtherInteractable(PlayerInteractableObjects other)
    {

        if (other is MeteoriteInteractable)
        {
            MeteoriteInteractable meteorite = other as MeteoriteInteractable;
            //InteractWithMeteorite(meteorite);
        }
        else if (other is PowerUp)
        {
            PowerUp powerUp = other as PowerUp;
            //InteractWithPowerUp(powerUp);
        }

        Destroy(gameObject);
        //Destroy(other.gameObject); maybe add this in the other object's coll func.
    }
}
