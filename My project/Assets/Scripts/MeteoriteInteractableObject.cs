using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteInteractable : PlayerInteractableObjects
{
    private float speed = 5f;
    private float speedIncrease = 0.5f;
    private float sizeFactor = 2f;
    public float horizontalSpeed;
    public float rotationSpeed = 100f;
    private float horizontalDirection;
    public GameObject[] impactPrefab;

    public bool isLastMeteorite = false;

    void Start()
    {
        speed = GameManager.Instance.GetLevelData().meteoriteInitialSpeed;
        speedIncrease = GameManager.Instance.GetLevelData().meteoriteSpeedIncreaseFactor;
        sizeFactor = GameManager.Instance.GetLevelData().meteoriteSizeFactor;
        horizontalSpeed = Random.Range(1f, 4f);
        horizontalDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        if (!GetComponent<Collider2D>())
        {
            gameObject.AddComponent<CircleCollider2D>().isTrigger = true;
        }
    }

    void Update()
    {
        Move();

        if (transform.position.x <= -1.9 || transform.position.x >= 1.9)
        {
            horizontalDirection *= -1;
        }

        if (transform.position.y <= -4){
            Destroy(gameObject);
            impactAnimation();
            if(!GameManager.Instance.GameFinished && !GameManager.Instance.ShieldUp){
                GameManager.Instance.ChangeLive(-1);
            }
        }
    }

    protected override void Move()
    {
        transform.position += Vector3.down * (speed * Time.deltaTime);
        transform.position += Vector3.right * (horizontalDirection * horizontalSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public override void InteractWithOtherInteractable(PlayerInteractableObjects other)
    {
        Debug.Log("Interacting with another interactable");
        if (other is BulletInteractableObject)
        {
            Debug.Log("Interacted with BulletInteractableObject");
            Destroy(gameObject);
            impactAnimation();
            if (isLastMeteorite)
            {
                GameManager.Instance.FinishGame(true);
            }
        }       
    }

    private void impactAnimation()
    {
        int impactPrefabIndex = Random.Range(0, impactPrefab.Length);
        GameObject impactPref = Instantiate(impactPrefab[impactPrefabIndex], transform.position, Quaternion.identity);
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

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        Debug.Log("Started coroutine to destroy object after delay");
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
