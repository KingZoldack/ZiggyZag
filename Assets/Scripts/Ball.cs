using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    Rigidbody _rb;

    [SerializeField]
    Animator _anim, _panelAnim;

    [SerializeField]
    float _speed;

    public bool hasStarted, canClickNow = true;

    [SerializeField] GameObject _particles;
    [SerializeField] GameObject[] _dustTrailParticles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _rb = GetComponent<Rigidbody>();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        GameManager.instance.LoadHighscore();

    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted && canClickNow)
        {
            StartGame();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) //If player falls off
        {
            ProcessGameOver();
        }

        if (Input.GetMouseButtonDown(0) && !PlatformSpawner.instance.isGameOver)
        {
            SwitchDirection();
        }
    }

    private void StartGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector3(_speed, 0, 0);
            hasStarted = true;
            _anim.SetBool("startGame", true);
            _panelAnim.SetBool("startGame", true);
            GameManager.instance.StartScoreCount();
            PlatformSpawner.instance.StartSpawning();
        }
    }

    private void ProcessGameOver()
    {
        UIManager.instance.GameOver();
        GameManager.instance.StopScoreCount();
        GameManager.instance.CheckForHighscore();
        _rb.velocity = new Vector3(0, -25f, 0);
        UIManager.instance._currentScoreText.enabled = false;
    }

    void SwitchDirection()
    {
        if (_rb.velocity.z > 0)
        {
            _dustTrailParticles[1].SetActive(true);
            _dustTrailParticles[0].SetActive(false);
            AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(_speed, 0, 0);
        }

        else if (_rb.velocity.x > 0)
        {
            _dustTrailParticles[0].SetActive(true);
            _dustTrailParticles[1].SetActive(false);
            AudioManager.instance.PlayClickSound();
            _rb.velocity = new Vector3(0, 0, _speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            AudioManager.instance.PlayCollectionSound();
            GameManager.instance.CollectableBonus();
            GameObject parts = Instantiate(_particles, other.transform.position, Quaternion.identity);
            Destroy(parts, 1f);
            Destroy(other.gameObject);
        }
    }
}
