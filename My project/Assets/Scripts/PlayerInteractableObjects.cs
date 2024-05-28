using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteractableObjects : MonoBehaviour
{

    //add collider2d here if it is needed in parent
    protected new Collider2D collider2D;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteractableObjects otherObject = other.GetComponent<PlayerInteractableObjects>();
        if (otherObject != null)
        {
            InteractWithOtherInteractable(otherObject);
        }
    }

    public abstract void InteractWithOtherInteractable(PlayerInteractableObjects otherObject);
    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
