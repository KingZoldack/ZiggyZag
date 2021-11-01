using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TutorialManager : TutorialCheckpoints
{
    [SerializeField] GameObject _gamOverPanel;
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _collectable;
    [SerializeField] GameObject[] _dustTrailParticles;
    [SerializeField] Animator _startTextAnim;
    [SerializeField] Animator _fingerPressAnim;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Text _scoreText;
    [SerializeField] float _speed;


    Vector3 _lastSpawnPosition;
    int spawnIndex = 1;
    float size;
    bool canStart;
    bool hasStarted;

    private void Awake()
    {
    }

    private void Start()
    {
        _lastSpawnPosition = _platform.transform.position; //This gets the last position of the platform.
        size = _platform.transform.localScale.x; //This get the size of the platform.


        for (int i = 0; i < 11; i++) //Spawns 11 platforms at start.
        {
            SpawnPlatforms();
            
        }
    }

    private void Update()
    {
        if (playableDirector.time >= 2.25f && !canStart)
        {
            playableDirector.Pause();
            canStart = true;
        }

        if (playableDirector.time >= 3f)
        {
            DisplayScore();
        }

        if (!hasStarted)
        {
            StartTutorial();
        }

        if (_atCheck1)
        {
            playableDirector.Pause();
            _rb.velocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                _atCheck1 = false;
                playableDirector.Resume();
                _rb.velocity = new Vector3(0, 0, _speed);
                GoLeft();
            }
        }

        if (_atCheck2)
        {
            playableDirector.Pause();
            _rb.velocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                _atCheck2 = false;
                playableDirector.Resume();
                _rb.velocity = new Vector3(_speed, 0, 0);
                GoRight();
            }
        }

        if (_atCheck3)
        {
            playableDirector.Pause();
            _rb.velocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                _atCheck3 = false;
                playableDirector.Resume();
                _rb.velocity = new Vector3(0, 0, _speed);
                GoLeft();
            }
        }

        if (_atCheck4)
        {
            playableDirector.Pause();
            _rb.velocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                _atCheck4 = false;
                playableDirector.Resume();
                _rb.velocity = new Vector3(_speed, 0, 0);
            }
        }

        if (_atEnd)
        {
            _atEnd = false;
            playableDirector.Stop();
            _rb.velocity = Vector3.zero;
            UIManager.instance.CurrentScoreText().enabled = false;
            _gamOverPanel.SetActive(true);
        }
    }

    public PlayableDirector PlayableDirector()
    {
        return playableDirector;
    }

    void SpawnPlatforms()
    {
        if (spawnIndex <= 3) //Spawns Z
        {
            Vector3 pos = _lastSpawnPosition; //Grabs last position
            pos.z += size; //Set new position to spawn (which is equal to the size of the object)
            _lastSpawnPosition = pos; //Sets new last position.
            Instantiate(_platform, pos, Quaternion.identity);
        }

        else if (spawnIndex > 3) //Spawns X
        {
            Vector3 pos = _lastSpawnPosition; //Grabs last position
            pos.x += size; //Set new position to spawn (which is equal to the size of the object)
            _lastSpawnPosition = pos; //Sets new last position.
            Instantiate(_platform, pos, Quaternion.identity);

            if (spawnIndex == 7)
            {
                Vector3 posOffset = new Vector3(pos.x, pos.y + 1, pos.z);
                Instantiate(_collectable, posOffset, _collectable.transform.rotation);
            }
        }

        spawnIndex++;
    }

    private void StartTutorial()
    {
        if (canStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startTextAnim.SetBool(Tags.GET_START_GAME_TAG, true);
                _fingerPressAnim.SetBool(Tags.GET_START_GAME_TAG, true);
                playableDirector.Resume();
                _rb.velocity = new Vector3(0, 0, _speed);
                hasStarted = true;
                GameManager.instance.StartScoreCount();
            }
        }
    }

    void GoRight()
    {
        if (_rb.velocity.x > 0) //If force is being applies on the X, add force to the Z instead. This is called when the player taps the screen.
        {
            _dustTrailParticles[0].SetActive(true);
            _dustTrailParticles[1].SetActive(false);
            //AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(0, 0, _speed);
        }
    }

    void GoLeft()
    {
        if (_rb.velocity.z > 0) //If force is being applies on the Z, add force to the X instead. This is called when the player taps the screen.
        {
            _dustTrailParticles[1].SetActive(true);
            _dustTrailParticles[0].SetActive(false);
            //AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(_speed, 0, 0);
        }
    }
    
    void DisplayScore()
    {
        UIManager.instance.CurrentScoreText().enabled = true;
        UIManager.instance.CurrentScoreText().text = GameManager.instance.Score().ToString();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Tags.GET_MAIN_MENU_TAG);
        _gamOverPanel.SetActive(false);
    }
}
