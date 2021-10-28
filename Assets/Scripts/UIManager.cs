using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    GameObject _gameOverPanelContainer;

    public Text _currentScoreText, _scoreValueText, _bestScoreValueText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        _currentScoreText.enabled = false;
        _gameOverPanelContainer.SetActive(true);
        PlatformSpawner.instance.isGameOver = true;
        GameManager.instance.DisplayScore();
        GameManager.instance.DisplayHighscore();
        Ball.instance.canClickNow = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSelectionMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
