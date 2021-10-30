using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    
    [SerializeField] Animator _anim;
    [SerializeField] GameObject _particles;
    [SerializeField] GameObject[] _dustTrailParticles;
    [SerializeField] float _speed;

    Rigidbody _rb;
    bool hasStarted = false; //Determins if the gams has started.
    bool canClickNow = true; //Variable set to determin if the player can click the screen when "Tap to start" is displayed.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        GameManager.instance.LoadHighscore();
    }

    void Update()
    {

        if (!hasStarted && canClickNow)
        {
            StartGame();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) //Casts a ray which checks if the player is on a platform. If not, player will fall.
        {
            ProcessGameOver();
        }

        if (Input.GetMouseButtonDown(0) && !PlatformSpawner.instance.IsGameOver())
        {
            ChangeDirections();
        }
    }

    public void CantClickNow()
    {
        canClickNow = false;
    }

    public bool HasStarted()
    {
        return hasStarted;
    }

    private void StartGame()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _rb.velocity = new Vector3(_speed, 0, 0);
        //    hasStarted = true;
        //    _anim.SetBool(Tags.GET_START_GAME_TAG, true); //Animation for start text in Level 1 secene.
        //    GameManager.instance.StartScoreCount();
        //    PlatformSpawner.instance.StartSpawning();
        //}
    }

    private void ProcessGameOver()
    {
        UIManager.instance.GameOver();
        GameManager.instance.StopScoreCount();
        GameManager.instance.CheckForHighscore();
        _rb.velocity = new Vector3(0, -25f, 0); //Player falls down is no platform is detected.
    }

    void ChangeDirections()
    {
        if (_rb.velocity.z > 0) //If force is being applies on the Z, add force to the X instead. This is called when the player taps the screen.
        {
            _dustTrailParticles[1].SetActive(true);
            _dustTrailParticles[0].SetActive(false);
            AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(_speed, 0, 0);
        }

        else if (_rb.velocity.x > 0) //If force is being applies on the X, add force to the Z instead. This is called when the player taps the screen.
        {
            _dustTrailParticles[0].SetActive(true);
            _dustTrailParticles[1].SetActive(false);
            AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(0, 0, _speed);
        }
    }

    private void OnTriggerEnter(Collider other)  //Collectable collision handler.
    {
        if (other.tag == Tags.GET_COLLECTABLE_TAG)
        {
            AudioManager.instance.PlayCollectionSound();
            GameManager.instance.CollectableBonus();
            GameObject collectablePartEffect = Instantiate(_particles, other.transform.position, Quaternion.identity);
            Destroy(collectablePartEffect, 1f);
            Destroy(other.gameObject);
        }
    }
}
