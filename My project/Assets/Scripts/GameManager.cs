using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreTextTMP;
    public TextMeshProUGUI liveTextTMP;
    public GameOverHandler gameOverHandler;

    private int _score = 0;
    private int _lives = 5;
    private LevelData _levelData;
    private bool _gameFinished = false;
    public bool GameFinished => _gameFinished;

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
        _levelData = LevelDataManager.GetLevelData();
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
        
        if (_lives <= 0)
        {
            FinishGame(false);
        }
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
    
    public void FinishGame(bool isWin)
    {
        Debug.Log("Game finished");
        _gameFinished = true;
        gameOverHandler.SetGameOver(isWin);
        if (isWin)
        {
            LevelDataManager.IncreaseSelectedLevel();
        }
        
        Destroy(gameObject);
    }
}

