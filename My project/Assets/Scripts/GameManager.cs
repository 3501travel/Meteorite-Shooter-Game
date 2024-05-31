using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreTextTMP;
    public TextMeshProUGUI liveTextTMP;

    private int _score = 0;
    private int _lives = 5;

    private LevelData _levelData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGameData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeGameData()
    {
        _levelData = LevelDataManager.GetLevelData(1);
        UpdateUI();
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreTextTMP.text = "Score: " + _score.ToString();
        liveTextTMP.text = "Live: " + _lives.ToString();
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        scoreTextTMP.text = "Score: " + _score.ToString();
    }

    public void ChangeLive(int amount)
    {
        _lives += amount;
        liveTextTMP.text = "Live: " + _lives.ToString();
    }
    
    public LevelData GetLevelData()
    {
        return _levelData;
    }
    
    public int GetScore()
    {
        return _score;
    }
    
    public int GetLives()
    {
        return _lives;
    }
}

