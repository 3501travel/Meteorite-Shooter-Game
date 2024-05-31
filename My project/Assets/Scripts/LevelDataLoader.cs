using UnityEngine;

public class LevelDataLoader : MonoBehaviour
{
    public LevelData[] levelDataArray;

    void Awake()
    {
        LevelDataManager.Initialize(levelDataArray);
        DontDestroyOnLoad(gameObject);
    }
}