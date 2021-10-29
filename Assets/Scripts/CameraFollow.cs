using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] float _lerpRate;

    Vector3 offset;

    void Start()
    {
        offset = _ball.transform.position - transform.position; //Returns the offset between the camera and the ball gameobject.
    }

    void Update()
    {
        if (!PlatformSpawner.instance.IsGameOver()) //As long as the game is not over.
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 cameraPos = transform.position;
        Vector3 tragetPos = _ball.transform.position - offset;
        cameraPos = Vector3.Lerp(cameraPos, tragetPos, _lerpRate);
        transform.position = cameraPos;
    }
}
