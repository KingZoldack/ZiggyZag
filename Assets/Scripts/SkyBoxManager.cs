using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] Material[] _skyBoxes;
    [SerializeField] float _changeDelayTime = 10f;
    [SerializeField] bool _isMainMenu;

    int _randomIndex;

    void Start()
    {
        StartCoroutine(ChangeSkyBox());
    }

    void Update()
    {
        var loadSelectedSkyBox = PlayerPrefs.GetInt("Selected SkyBox");

        if (!_isMainMenu)
        {
            StopAllCoroutines();
            RenderSettings.skybox = _skyBoxes[loadSelectedSkyBox];
        }
        
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

    public void SelectItemInSkyBox(int currentSelection, Material[] childMat)
    {
        RenderSettings.skybox = childMat[currentSelection];
        PlayerPrefs.SetInt("Current Selection", currentSelection);
    }
}
