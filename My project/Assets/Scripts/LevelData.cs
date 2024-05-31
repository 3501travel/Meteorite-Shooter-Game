using UnityEngine;



[CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    public int currentLevel;
    public float spawnIntervalFactor;
    public float meteoriteInitialSpeed;
    public float meteoriteSpeedIncreaseFactor;
    public int totalMeteoriteCount;
    public int totalPowerUpCount;
    public float meteoriteSizeFactor;
}

