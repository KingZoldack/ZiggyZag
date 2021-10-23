using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    [SerializeField] Material[] _skyBoxes;
    [SerializeField] float _changeDelayTime = 10f;

    int _randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSkyBox());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ChangeSkyBox()
    {

        while (true)
        {
            _randomIndex = Random.Range(0, _skyBoxes.Length - 1);

            RenderSettings.skybox = _skyBoxes[_randomIndex];
            yield return new WaitForSeconds(_changeDelayTime);
        }
    }
}
