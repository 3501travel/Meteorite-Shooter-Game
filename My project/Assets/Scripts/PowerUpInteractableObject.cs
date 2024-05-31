using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteractable : PlayerInteractableObjects
{
    public GameObject impactPrefab;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (!GetComponent<Collider2D>())
        {
            gameObject.AddComponent<CircleCollider2D>().isTrigger = true;
        }
        //destroy after 4 seconds if not hit.
        CoroutineRunner.EnsureInstance();
        CoroutineRunner.Instance.RunCoroutine(DestroyAfterDelay(gameObject, 4f)); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Move()
    {

    }

    public override void InteractWithOtherInteractable(PlayerInteractableObjects other)
    {
        Debug.Log("Interacting with another interactable");
        if (other is BulletInteractableObject)
        {
            // Player player = other.GetComponent<Player>();
            // if (player != null)
            // {
            //     ApplyPowerUp(player);
            //     Destroy(gameObject);
            // }
            Debug.Log("Powerup Interacted with BulletInteractableObject");
            Destroy(gameObject);
            GameObject impactPref = Instantiate(impactPrefab, transform.position, Quaternion.identity);
            Debug.Log("Impact prefab instantiated");

            CoroutineRunner.EnsureInstance();

            if (CoroutineRunner.Instance != null)
            {
                CoroutineRunner.Instance.RunCoroutine(DestroyAfterDelay(impactPref, 2f)); 
            }
            else
            {
                Debug.LogError("CoroutineRunner instance is null. Ensure CoroutineRunner is present in the scene.");
            }
        }       
    }

    void ApplyPowerUp()
    {
        // Define the power-up effect
        // Example: Increase player's speed
        //player.IncreaseSpeed();
    }

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        Debug.Log("Started coroutine to destroy unhit powerup after time passed.");
        yield return new WaitForSecondsRealtime(delay);
        Debug.Log("Waited for " + delay + " seconds");
        if (obj != null)
        {
            Debug.Log("Destroying impact prefab after delay");
            Destroy(obj);
        }
        else
        {
            Debug.LogWarning("Impact prefab is already destroyed or null");
        }
    }
}
