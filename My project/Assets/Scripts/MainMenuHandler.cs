using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    
    [SerializeField] private Button levelsButton;
    [SerializeField] private Button arenaButton;
    [SerializeField] private Button storeButton;
    [SerializeField] private TextMeshProUGUI levelText;
    
    void Start()
    {
        levelsButton.onClick.AddListener(OnLevelsButtonClicked);
        arenaButton.onClick.AddListener(OnArenaButtonClicked);
        storeButton.onClick.AddListener(OnStoreButtonClicked);
        levelText.text = "Level " + LevelDataManager.SelectedLevel;
    }
    
    void Update()
    {
        
    }
    
    private void OnLevelsButtonClicked()
    {
        Debug.Log("Levels button clicked");
        LevelDataManager.IsArenaMode = false;
        SceneManager.LoadScene("GameScene");
    }
    
    private void OnArenaButtonClicked()
    {
        // Change scene to GameScene
        LevelDataManager.IsArenaMode = true;
        SceneManager.LoadScene("GameScene");
    }
    
    private void OnStoreButtonClicked()
    {
        Debug.Log("Store button clicked");
    }
}
