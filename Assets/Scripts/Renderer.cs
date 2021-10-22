using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer : MonoBehaviour
{
    List<Material> _platformMaterial = new List<Material>();
    List<Material> _currentPlatformMaterial = new List<Material>();
    Renderer _platformRenderer;

    private void Awake()
    {
        _platformRenderer = GetComponent<Renderer>();


        if (_platformMaterial == null)
        {
            return;
        }

        else
        {
            _currentPlatformMaterial = _platformMaterial;
        }
        Debug.Log(_platformMaterial.Count);
        Debug.Log("C:" + _platformMaterial.Count);


    }

    private void Start()
    {

    }

    private void Update()
    {

        foreach (var item in _platformMaterial)
        {
            Debug.Log("item " + item);
        }
        Debug.Log(_platformMaterial.ToString());

        //_platformRenderer.material = _platformMaterial[1];
    }
}
