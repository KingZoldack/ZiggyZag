using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    GameObject _platform, _collectable;

    Vector3 _lastSpawnPosition;

    float size;

    public bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _lastSpawnPosition = _platform.transform.position;
        size = _platform.transform.localScale.x;
        

        for (int i = 0; i < 15; i++)
        {
            SPawnPlatforms();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            CancelInvoke("SPawnPlatforms");
        } 
    }

    void SPawnPlatforms()
    {
        int rand = Random.Range(0, 6);

        if (rand <= 3)
        {
            SpawnX();
        }

        else if (rand >= 4)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = _lastSpawnPosition;
        pos.x += size;
        _lastSpawnPosition = pos;
        Instantiate(_platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 5);

        if (rand < 1)
        {
            Vector3 posOffset = new Vector3(pos.x, pos.y + 1, pos.z);
            Instantiate(_collectable, posOffset, _collectable.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = _lastSpawnPosition;
        pos.z += size;
        _lastSpawnPosition = pos;
        Instantiate(_platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 5);

        if (rand < 1)
        {
            Vector3 posOffset = new Vector3(pos.x, pos.y + 1, pos.z);
            Instantiate(_collectable, posOffset, _collectable.transform.rotation);
        }
    }

    public void StartSpawning()
    {
        InvokeRepeating("SPawnPlatforms", 1.5f, 0.2f);
    }
}
