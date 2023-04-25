using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI highScorePanelText;

    [Header("UI Panel")]
    [SerializeField] GameObject gameOverPanel;

    int score;
    int highScore;

    void Awake()
    {
        Advertisement.Initialize("5166105");
        gameOverPanel.SetActive(false);

        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best: " + highScore.ToString();
        
    }

    /// <summary>
    /// Increases score And sets highscore
    /// </summary>
    /// <param name="points"></param>
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    /// <summary>
    /// Activates advertisement and starts the bomb hit sequence
    /// </summary>
    public void BombHit()
    {
        Advertisement.Show("BombHit");
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
        highScorePanelText.text = "Best: " + highScore.ToString();
        Time.timeScale = 0;
    }

    /// <summary>
    /// Restarts the game Scene
    /// </summary>
    public void RestartGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Quits game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }
}
