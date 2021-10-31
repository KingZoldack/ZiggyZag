using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialManager : TutorialCheckpoints
{
    [SerializeField] GameObject _startText;
    [SerializeField] GameObject[] _dustTrailParticles;
    [SerializeField] Animator _startTextAnim;
    [SerializeField] Animator _fingerPressAnim;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    
    bool canStart;
    bool hasStarted;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Time.time >= 2.5f && !canStart)
        {
            playableDirector.Pause();
            canStart = true;
        }

        if (!hasStarted)
        {
            StartTutorial();
        }

        if (Input.GetMouseButtonDown(0) && !PlatformSpawner.instance.IsGameOver())
        {
            ChangeDirections();
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
                ChangeDirections();
            }
        }
    }

    public PlayableDirector PlayableDirector()
    {
        return playableDirector;
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
                _rb.velocity = new Vector3(_speed, 0, 0);
                hasStarted = true;
                GameManager.instance.StartScoreCount();
                //PlatformSpawner.instance.StartSpawning();
            }
        }
    }

    void ChangeDirections()
    {
        if (_rb.velocity.z > 0) //If force is being applies on the Z, add force to the X instead. This is called when the player taps the screen.
        {
            _dustTrailParticles[1].SetActive(true);
            _dustTrailParticles[0].SetActive(false);
            //AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(_speed, 0, 0);
        }

        else if (_rb.velocity.x > 0) //If force is being applies on the X, add force to the Z instead. This is called when the player taps the screen.
        {
            _dustTrailParticles[0].SetActive(true);
            _dustTrailParticles[1].SetActive(false);
            //AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(0, 0, _speed);
        }
    }
    
}
