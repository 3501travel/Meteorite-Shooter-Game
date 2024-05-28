using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : PlayerInteractableObjects
{
    public float speed = 2f;

    void Start()
    {

    }

    protected override void Move()
    {
        // Move the power-up downward
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public override void InteractWithOtherInteractable(PlayerInteractableObjects other)
    {
        /*Player player = other.GetComponent<Player>();
        if (player != null)
        {
            ApplyPowerUp(player);
            Destroy(gameObject);
        }*/
    }

    /*void ApplyPowerUp(Player player)
    {
        // Define the power-up effect
        // Example: Increase player's speed
        player.IncreaseSpeed();
    }*/
}
