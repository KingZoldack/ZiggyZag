using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset;

    [SerializeField]
    GameObject _ball;

    [SerializeField]
    float _lerpRate;

    // Start is called before the first frame update
    void Start()
    {
        offset = _ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlatformSpawner.instance.isGameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 tragetPos = _ball.transform.position - offset;
        pos = Vector3.Lerp(pos, tragetPos, _lerpRate);
        transform.position = pos;
    }
}
