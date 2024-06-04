using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{    
    public GameObject[] meteoritePrefabs;
    public float spawnIntervalFactor = 2f;
    private int meteoriteCount = 0;

    void Start()
    {
        meteoriteCount = GameManager.Instance.GetLevelData().totalMeteoriteCount;
        spawnIntervalFactor = GameManager.Instance.GetLevelData().spawnIntervalFactor;
        StartCoroutine(SpawnMeteorites());
    }

    IEnumerator SpawnMeteorites()
    {
        for (int i = 0; i < meteoriteCount; i++)
        {
            Vector3 spawnPoint = CreateSpawnPoint();
            float spawnInterval = Random.Range(spawnIntervalFactor*0.75f, spawnIntervalFactor*1.25f);
            yield return new WaitForSeconds(spawnInterval);
            int meteoriteIndex = Random.Range(0, meteoritePrefabs.Length);
              if (i == meteoriteCount - 1) // Check if last meteorite
                {
                    Instantiate(meteoritePrefabs[meteoriteIndex], spawnPoint, Quaternion.identity).GetComponent<MeteoriteInteractable>().isLastMeteorite = true;
                }
                else
                {
                    Instantiate(meteoritePrefabs[meteoriteIndex], spawnPoint, Quaternion.identity);
                }
            if(spawnIntervalFactor > 0.5f) spawnIntervalFactor -= 0.02f;
        }
        //GameManager.Instance.FinishGame(true);
    }
    
    Vector3 CreateSpawnPoint()
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        float randomX = Random.Range(-1, 1);
        Vector3 spawnPosition = new Vector3(randomX*1.5f, 5, 0);
        return spawnPosition;
    }
}
