using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject _gameOverPanelContainer;
    [SerializeField] Text _currentScoreText;
    [SerializeField] Text _scoreValueText;
    [SerializeField] Text _bestScoreValueText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Text CurrentScoreText()
    {
        return _currentScoreText;
    }

    public Text ScoreValueText()
    {
        return _scoreValueText;
    }

    public Text BestScoreValueText()
    {
        return _bestScoreValueText;
    }

    public void GameOver()
    {
        _currentScoreText.gameObject.SetActive(false);
        _gameOverPanelContainer.SetActive(true);
        PlatformSpawner.instance.GameIsOver();
        GameManager.instance.DisplayScore();
        GameManager.instance.DisplayHighscore();
        Ball.instance.CantClickNow();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Tags.GET_MAIN_MENU_TAG);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(Tags.GET_GAME_SCENE_TAG);
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadSelectionMenu()
    {
        SceneManager.LoadScene(Tags.GET_SELECETION_MENU_TAG);
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(Tags.GET_TUTORIAL_MENU_TAG);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
