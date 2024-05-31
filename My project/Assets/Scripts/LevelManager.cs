using UnityEngine;
using System.Collections.Generic;

public static class LevelDataManager
{
    private static Dictionary<int, LevelData> levels = new Dictionary<int, LevelData>();

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

    public static LevelData GetLevelData(int level)
    {
        if (levels.TryGetValue(level, out LevelData levelData))
        {
            return levelData;
        }
        Debug.LogError($"Level data not found for level {level}");
        return null;
    }
}