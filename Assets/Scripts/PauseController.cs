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
    public GameObject tutorPanel;
    public GameObject gameOverPanel;
    public AudioSource shopSFX;

    private void Start()
    {
        pauseMenu.SetActive(false);
        shopPanel.SetActive(false);
        tutorGame();
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
            shopSFX.Play();
        }
    }

    public void tutorGame()
    {
        tutorPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
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

    public void ClosePanel()
    {
        Time.timeScale = 1f;
        tutorPanel.SetActive(false);
    }

    public void RetryButton(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void gameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
