using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{    
    public GameObject[] meteoritePrefabs;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;

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
            int meteoriteIndex = Random.Range(0, meteoritePrefabs.Length);
            Instantiate(meteoritePrefabs[meteoriteIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
    Transform[] CreateSpawnPoints(int numberOfPoints)
    {
        Transform[] points = new Transform[numberOfPoints];
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float randomX = Random.Range(-1, 1);
            Vector3 spawnPosition = new Vector3(randomX*1.8f, 5, 0);
            GameObject spawnPoint = new GameObject("SpawnPoint" + i);
            spawnPoint.transform.position = spawnPosition;
            points[i] = spawnPoint.transform;
        }

        return points;
    }
}
