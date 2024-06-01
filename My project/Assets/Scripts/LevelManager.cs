using UnityEngine;
using System.Collections.Generic;

public static class LevelDataManager
{
    private static Dictionary<int, LevelData> levels = new();

    public static bool IsArenaMode = true;
    
    public static int SelectedLevel
    {
        get
        {
            return 1;
            return PlayerPrefs.GetInt("SelectedLevel", 1);
        }
        set
        {
            PlayerPrefs.SetInt("SelectedLevel", value);
        }
    }

    public static void Initialize(LevelData[] levelDataArray)
    {
        levels.Clear();
        foreach (var levelData in levelDataArray)
        {
            if (!levels.ContainsKey(levelData.currentLevel))
            {
                levels.Add(levelData.currentLevel, levelData);
            }
        }
    }

    public static LevelData GetLevelData()
    {
        int level = IsArenaMode ? 0 : SelectedLevel;
        
        if (levels.TryGetValue(level, out LevelData levelData))
        {
            return levelData;
        }
        Debug.LogError($"Level data not found for level {SelectedLevel}");
        return null;
    }
    
    public static void IncreaseSelectedLevel()
    {
        SelectedLevel++;
    }
}