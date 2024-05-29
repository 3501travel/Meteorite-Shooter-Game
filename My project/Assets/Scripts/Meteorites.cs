using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{    
    public GameObject meteoritePrefab;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;
    public float speed = 30f;

    void Start()
    {
        spawnPoints = CreateSpawnPoints(10);
        StartCoroutine(SpawnMeteorites());
    }

    IEnumerator SpawnMeteorites()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(meteoritePrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
    Transform[] CreateSpawnPoints(int numberOfPoints)
    {
        Transform[] points = new Transform[numberOfPoints];
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float randomX = Random.Range(-2, 2);
            Vector3 spawnPosition = new Vector3(randomX, 5, 0);
            GameObject spawnPoint = new GameObject("SpawnPoint" + i);
            spawnPoint.transform.position = spawnPosition;
            points[i] = spawnPoint.transform;
        }

        return points;
    }
}
