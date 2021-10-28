using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] Material[] _skyBoxes;
    [SerializeField] float _changeDelayTime = 10f;
    [SerializeField] bool _isMainMenu;

    int _randomIndex;

    private void Awake()
    {
        int numOfSkyBoxManager = FindObjectsOfType<SkyBoxManager>().Length;
        if (numOfSkyBoxManager > 1)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    void Update()
    {
        var pref = PlayerPrefs.GetInt("Selected SkyBox");

        if (!_isMainMenu)
        {
            RenderSettings.skybox = _skyBoxes[pref];
            Debug.Log("==>" + pref);
        }

        else if (_isMainMenu)
        {
            StartCoroutine(ChangeSkyBox());
        }
        
        
    }

    IEnumerator ChangeSkyBox()
    {
        while (true)
        {
            _randomIndex = Random.Range(0, _skyBoxes.Length - 1);

            for (int i = 0; i < _skyBoxes.Length; i++)
            {
                yield return new WaitForSeconds(_changeDelayTime);

                RenderSettings.skybox = _skyBoxes[i];

            }
            //foreach (var skybox in _skyBoxes)
            //{
            //    RenderSettings.skybox = skybox;

            //}

            //yield return new WaitForEndOfFrame();

        }
    }

    public void SelectItemInSkyBox(int currentSelection, Material[] childMat)
    {
        RenderSettings.skybox = childMat[currentSelection];
        PlayerPrefs.SetInt("Current Selection", currentSelection);
    }
}
