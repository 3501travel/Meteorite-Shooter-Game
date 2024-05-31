using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreTextTMP;
    public TextMeshProUGUI liveTextTMP;

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
        GameData.score = 0;
        GameData.lives = 5;
        GameData.currentLevel = 1;
        UpdateUI();
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreTextTMP.text = "Score: " + GameData.score.ToString();
        liveTextTMP.text = "Live: " + GameData.lives.ToString();
    }

    public void IncreaseScore(int amount)
    {
        GameData.score += amount;
        scoreTextTMP.text = "Score: " + GameData.score.ToString();
    }

    public void ChangeLive(int amount)
    {
        GameData.lives += amount;
        liveTextTMP.text = "Live: " + GameData.lives.ToString();
    }
}

