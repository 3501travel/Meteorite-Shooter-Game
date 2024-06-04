using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInteractable : PlayerInteractableObjects
{
    public GameObject impactPrefab;

    public enum PowerUpType { PurpleHeart, Ammo, Hourglass, ShieldMetal }
    public PowerUpType powerUpType;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Collider2D>())
        {
            gameObject.AddComponent<CircleCollider2D>().isTrigger = true;
        }
        //destroy after 4 seconds if not hit.
        StartCoroutine(DestroyAfterDelay(gameObject, 4f));
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
            ApplyPowerUp((BulletInteractableObject) other);
            Destroy(gameObject);
            impactAnimation();
        }       
    }
    
    private void impactAnimation()
    {
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

    void ApplyPowerUp(BulletInteractableObject bulletInteractableObject)
{
    switch (powerUpType)
    {
        case PowerUpType.PurpleHeart:
            GameManager.Instance.ChangeLive(1);
            break;
        case PowerUpType.Ammo:
            bulletInteractableObject.GetGun().IncreaseBulletCount(2);
            break;
        case PowerUpType.Hourglass:
            //Slow down time for 5 seconds
            Time.timeScale = 0.5f;
            GameManager.Instance.StartCoroutine(ResetTimeScale(5f));
            break;
        case PowerUpType.ShieldMetal:
            // Activate shield logic to prevent life decrease.
            GameManager.Instance.ShieldUp = true;
            GameManager.Instance.StartCoroutine(ResetShield(8f));
            break;
        default:
            Debug.LogError("Unidentified power-up tag: " + powerUpType);
            break;
    }
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
    
    private IEnumerator ResetTimeScale(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }
    
    private IEnumerator ResetShield(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        GameManager.Instance.ShieldUp = false;
    }
}
