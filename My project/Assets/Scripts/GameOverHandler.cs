using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject gameOverCanvas;

    void Start()
    {
        Debug.Log("GameOverHandler Start");

        // Verify that buttons are not null
        if (menuButton == null || restartButton == null || nextButton == null)
        {
            Debug.LogError("One or more buttons are not assigned in the inspector.");
            return;
        }

        // Attach listeners to buttons
        menuButton.onClick.AddListener(OnMenuButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // Initially hide the game over canvas
        gameOverCanvas.SetActive(false);
    }

    private void OnMenuButtonClicked()
    {
        Debug.Log("Menu button clicked");
        SceneManager.LoadScene("MainMenuScene");
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
        Debug.Log("SetGameOver called with isWin: " + isWin);

        gameOverCanvas.SetActive(true);

        string text = isWin ? "Level Completed!" : "Game Over!";
        gameOverText.text = text;

        restartButton.gameObject.SetActive(!isWin);
        nextButton.gameObject.SetActive(isWin);

        Debug.Log("Is gameOverCanvas active: " + gameOverCanvas.activeSelf);
        Debug.Log("Is restartButton active: " + restartButton.gameObject.activeSelf);
        Debug.Log("Is nextButton active: " + nextButton.gameObject.activeSelf);
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
