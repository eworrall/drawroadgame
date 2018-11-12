using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private string gameLevel = "gameScene";

    // Use this for initialization
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    // Update is called once per frame
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        //FindObjectOfType<EventSystem>().Reset();
        pauseMenu.SetActive(false);
        FindObjectOfType<EventSystem>().RestartGame();
        Time.timeScale = 1f;
        
    }
}
