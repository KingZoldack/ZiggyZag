using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int _score;
    int _highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        DisplayCurrentScore();
    }

    public void IncrementScore()
    {
        _score++;
    }

    public void CollectableBonus()
    {
        _score += 5; 
    }
    public void StartScoreCount()
    {
        InvokeRepeating(nameof(IncrementScore), 0.1f, 2f);
    }

    public void StopScoreCount()
    {
        CancelInvoke(nameof(IncrementScore));
    }

    public void CheckForHighscore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt(Tags.GET_HIGHSCORE_TAG, _highScore);
        }
    }

    public void LoadHighscore()
    {
       _highScore = PlayerPrefs.GetInt(Tags.GET_HIGHSCORE_TAG, 0);
    }

    public void DisplayCurrentScore()
    {
        if (Ball.instance.HasStarted())
        {
            UIManager.instance.CurrentScoreText().enabled = true;
            UIManager.instance.CurrentScoreText().text = _score.ToString();
        }
    }

    public void DisplayScore()
    {
        UIManager.instance.ScoreValueText().text = _score.ToString();
    }

    public void DisplayHighscore()
    {
        UIManager.instance.BestScoreValueText().text = _highScore.ToString();
    }
}
