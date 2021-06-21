using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScoreTxt;

    public int score = 0;
    
    public void Awake()
    {
        
        if (SceneManager.GetActiveScene().name == "Game1" || SceneManager.GetActiveScene().name == "Game2" || SceneManager.GetActiveScene().name == "Game3")
        {
            scoreTxt = GameObject.Find("ScoreNum").GetComponent<Text>();
            highScoreTxt = GameObject.Find("HighScoreNum").GetComponent<Text>();
        }
        
        UpdateHighScore();
    }

    
    public void Update()
    {
        scoreTxt = GameObject.Find("ScoreNum")?.GetComponent<Text>();
        highScoreTxt = GameObject.Find("HighScoreNum")?.GetComponent<Text>();
        if (scoreTxt != null && highScoreTxt != null)
        {
            UpdateHighScore();
            UpdateScore();
        }
        
    }

    public void IncreaseScoreOnHit()
    {
        score++;
        UpdateHighScore();
        scoreTxt.text = score.ToString();
    }

    public void IncreaseScoreOnDestroy()
    {
        score += 100;
        UpdateHighScore();
        scoreTxt.text = score.ToString();
    }

    public void UpdateHighScore()
    {
        var highScore = GetHighScore();
        
        if (score > highScore)
        {
            highScoreTxt.text = score.ToString();
        }
        else
        {
            highScoreTxt.text = highScore.ToString();
        }
    }

    public void UpdateScore()
    {
        scoreTxt.text = score.ToString();
    }
    
    public void SaveScore()
    {
        GameObject.Find("ScoreStore").GetComponent<ScoreStore>().SaveScore(score);
    }

    private int GetHighScore()
    {
        var store = GameObject.Find("ScoreStore").GetComponent<ScoreStore>();
        var highScore = store.GetTopScores().FirstOrDefault();

        return highScore.Value;
    }
}
