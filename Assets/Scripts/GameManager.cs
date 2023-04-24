using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI highScorePanelText;
    [SerializeField] GameObject gameOverPanel;

    int score;
    int highScore;
   


    private void Awake()
    {
        Advertisement.Initialize("5166105");
        gameOverPanel.SetActive(false);

        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best: " + highScore.ToString();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

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

    
}
