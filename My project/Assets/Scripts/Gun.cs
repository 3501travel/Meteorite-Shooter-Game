using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 30f;
    public int bulletCount = 5;

    void Start()
    {
    }

    public void SpawnBullet(Transform spawnPoint, float angle)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        // rotate the bullet in the direction of the angle
        bullet.transform.Rotate(Vector3.forward, angle);

        bullet.GetComponent<BulletInteractableObject>().SetDirection(new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0));
        bullet.GetComponent<BulletInteractableObject>().SetGun(this);
    }
    public void IncreaseBulletCount(int amount)
    {
        bulletCount += amount;
        Debug.Log("Bullet count increased. New count: " + bulletCount);
    }
}
