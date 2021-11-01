using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] Material[] _skyBoxes;
    [SerializeField] Material _TutorialSkyBox;
    [SerializeField] float _changeDelayTime = 10f;
    [SerializeField] bool _isMainMenu;
    [SerializeField] bool _isCoreGame;
    [SerializeField] bool _isTutorial;

    int _randomIndex;

    void Start()
    {
        StartCoroutine(ChangeSkyBoxRandomly());
    }

    void Update()
    {
        var loadSelectedSkyBox = PlayerPrefs.GetInt(Tags.GET_SELECTED_SKYBOX_TAG); //Gets seleceted sky box from Selector Scroller script.


        if (_isCoreGame) //If player is in core game, use the selected sky box.
        {
            StopAllCoroutines();
            RenderSettings.skybox = _skyBoxes[loadSelectedSkyBox];
        }

        if (_isTutorial)
        {
            RenderSettings.skybox = _TutorialSkyBox;
        }
        
    }

    IEnumerator ChangeSkyBoxRandomly() //Displays random sky boxes whilst in the main menu.
    {
        if (_isMainMenu)
        {
            while (true)
            {
                _randomIndex = Random.Range(0, _skyBoxes.Length);

                RenderSettings.skybox = _skyBoxes[_randomIndex];

                yield return new WaitForSeconds(_changeDelayTime);
            }
        }
        
    }

    public void SelectItemInSkyBox(int currentSelection, Material[] childMat) //Selects sky box and sets it to the current sky box.
    {
        RenderSettings.skybox = childMat[currentSelection];
    }
}
