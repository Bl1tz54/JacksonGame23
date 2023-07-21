using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
        // Load the scene "Game" when button is pressed
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
