using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int _score, _highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentScore();

        QuiteGame();
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
        InvokeRepeating("IncrementScore", 0.1f, 2f);
    }

    public void StopScoreCount()
    {
        CancelInvoke("IncrementScore");
    }

    public void CheckForHighscore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("Highscore", _highScore);
        }
    }

    public void LoadHighscore()
    {
       _highScore = PlayerPrefs.GetInt("Highscore", 0);
    }

    public void DisplayCurrentScore()
    {
        if (Ball.instance.hasStarted)
        {
            UIManager.instance._currentScoreText.enabled = true;
            UIManager.instance._currentScoreText.text = _score.ToString();
        }
    }

    public void DisplayScore()
    {
        UIManager.instance._scoreValueText.text = _score.ToString();
    }

    public void DisplayHighscore()
    {
        UIManager.instance._bestScoreValueText.text = _highScore.ToString();
    }

    void QuiteGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
