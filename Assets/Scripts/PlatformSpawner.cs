using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _collectable;

    Vector3 _lastSpawnPosition;
    float size;
    bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        _lastSpawnPosition = _platform.transform.position; //This gets the last position of the platform.
        size = _platform.transform.localScale.x; //This get the size of the platform.
        

        for (int i = 0; i < 15; i++) //Spawns 15 platforms at start.
        {
            SpawnPlatforms();
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            CancelInvoke(nameof(SpawnPlatforms));
        } 
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void GameIsOver()
    {
        isGameOver = true;
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 8);

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
        Vector3 pos = _lastSpawnPosition; //Grabs last position
        pos.x += size; //Set new position to spawn (which is equal to the size of the object)
        _lastSpawnPosition = pos; //Sets new last position.
        Instantiate(_platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 5);

        if (rand < 1) //Spawns collectable with a 1 in 5 chance.
        {
            Vector3 posOffset = new Vector3(pos.x, pos.y + 1, pos.z);
            Instantiate(_collectable, posOffset, _collectable.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = _lastSpawnPosition; //Grabs last position
        pos.z += size; //Set new position to spawn (which is equal to the size of the object)
        _lastSpawnPosition = pos; //Sets new last position.
        Instantiate(_platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 5);

        if (rand < 1) //Spawns collectable with a 1 in 5 chance.
        {
            Vector3 posOffset = new Vector3(pos.x, pos.y + 1, pos.z);
            Instantiate(_collectable, posOffset, _collectable.transform.rotation);
        }
    }

    public void StartSpawning() //Continuosly spawns platforms.
    {
        InvokeRepeating(nameof(SpawnPlatforms), 1.5f, 0.2f);
    }
}
