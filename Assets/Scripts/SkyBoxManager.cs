using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    [SerializeField] Material[] _skyBoxes;
    [SerializeField] float _changeDelayTime = 2f;

    int _randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        _randomIndex = Random.Range(0, _skyBoxes.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeSkyBox()
    {
        while (true)
        {
            RenderSettings.skybox = _skyBoxes[_randomIndex];

            yield return new WaitForSeconds(_changeDelayTime);
        }
    }
}
