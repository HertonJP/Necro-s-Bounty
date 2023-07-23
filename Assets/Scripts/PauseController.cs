using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseController : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject shopPanel;

    private void Start()
    {
        pauseMenu.SetActive(false);
        shopPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            shopPanel.SetActive(!shopPanel.activeSelf);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        shopPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void BackButton(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void RetryButton(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
