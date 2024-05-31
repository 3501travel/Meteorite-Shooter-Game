using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;

    void Start()
    {
        spawnPoints = CreateSpawnPoints(10);
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnPowerups()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            int powerupIndex = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[powerupIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    Transform[] CreateSpawnPoints(int numberOfPoints)
    {
        Transform[] points = new Transform[numberOfPoints];
        
        // Get the orthographic camera's dimensions
        Camera mainCamera = Camera.main;
        float screenHeight = mainCamera.orthographicSize * 2.0f;
        float screenWidth = screenHeight * mainCamera.aspect;

        for (int i = 0; i < numberOfPoints; i++)
        {
            // Generate random x and y coordinates within the screen bounds
            float randomX = Random.Range(-screenWidth / 2 + 0.5f, screenWidth / 2 - 0.5f);
            float randomY = Random.Range(0, screenHeight / 2.5f);
            
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            
            GameObject spawnPoint = new GameObject("SpawnPoint" + i);
            spawnPoint.transform.position = spawnPosition;
            
            points[i] = spawnPoint.transform;
        }

        return points;
    }

}
