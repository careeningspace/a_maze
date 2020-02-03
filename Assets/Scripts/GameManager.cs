using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public Button startButton;
    public Button resumeButton;
    public Button quitButton;
    public GameObject gameOver;
    public Player player;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerName;

    public int score;
    public int currentLevel;
    public int timer;
    public static bool m_IsGameActive;
    public static bool m_IsGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_IsGameActive)
        {
            if(m_IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void GameOver()
    {
        m_IsGameActive = false;
        gameOver.SetActive(true);
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        timer = 0;
        score = 0;
        m_IsGameActive = true;
        UpdateScore(score);
        startScreen.SetActive(false);
        Time.timeScale = 1.0f;
        StartCoroutine(TimeClock());
    }

    public void UpdateScore(int scoreToAdd)
    {
        
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        
    }

    IEnumerator TimeClock()
    {
        while (m_IsGameActive && !m_IsGamePaused)
        {
            yield return new WaitForSeconds(1.0f);
            timer += 1;
            timerText.text = "Time: " + timer;
        }
    }

    public void Pause()
    {
        
        m_IsGamePaused = true;
        startScreen.SetActive(true);
        startButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Time.timeScale = 0.0f;

    }

    public void Resume()
    {
        
        startScreen.SetActive(false);
        startButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        m_IsGamePaused = false;
        Time.timeScale = 1.0f;
    }
}
