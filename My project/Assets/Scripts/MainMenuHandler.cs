using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    
    [SerializeField] private Button levelsButton;
    [SerializeField] private Button arenaButton;
    [SerializeField] private Button storeButton;
    
    void Start()
    {
        levelsButton.onClick.AddListener(OnLevelsButtonClicked);
        arenaButton.onClick.AddListener(OnArenaButtonClicked);
        storeButton.onClick.AddListener(OnStoreButtonClicked);
    }
    
    void Update()
    {
        
    }
    
    private void OnLevelsButtonClicked()
    {
        Debug.Log("Levels button clicked");
    }
    
    private void OnArenaButtonClicked()
    {
        // Change scene to GameScene
        SceneManager.LoadScene("GameScene");
    }
    
    private void OnStoreButtonClicked()
    {
        Debug.Log("Store button clicked");
    }
}
