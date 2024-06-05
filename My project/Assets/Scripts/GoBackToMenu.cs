using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class GoBackToMenu : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        // Load the MainMenuScene
        SceneManager.LoadScene("MainMenuScene");
    }
}