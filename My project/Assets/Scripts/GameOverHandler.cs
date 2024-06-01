using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject gameOverCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameOverHandler Start");
        menuButton.onClick.AddListener(OnMenuButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);
        gameOverCanvas.SetActive(false);
    }
    
    private void OnMenuButtonClicked()
    {
        Debug.Log("Menu button clicked");
    }
    
    private void OnRestartButtonClicked()
    {
        Debug.Log("Restart button clicked");
    }
    
    private void OnNextButtonClicked()
    {
        Debug.Log("Next button clicked");
    }
    
    public void SetGameOver(bool isWin)
    {
        gameOverCanvas.SetActive(true);
        string text = isWin ? "Level Completed!" : "Game Over!";
        gameOverText.text = text;
        restartButton.gameObject.SetActive(!isWin);
        nextButton.gameObject.SetActive(isWin);
    }
    
    public void ShowGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }
    
    public void HideGameOverCanvas()
    {
        gameOverCanvas.SetActive(false);
    }
}
