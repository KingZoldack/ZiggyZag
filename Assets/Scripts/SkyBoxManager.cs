using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] Material[] _skyBoxes;
    [SerializeField] float _changeDelayTime = 10f;
    public bool _isRandomSelected;

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
        //StartCoroutine(ChangeSkyBox());
    }

    void Update()
    {
        var pref = PlayerPrefs.GetInt("Selected SkyBox");
        
        RenderSettings.skybox = _skyBoxes[pref];
        Debug.Log("==>" + pref);
        //if (pref == _skyBoxes.Length - 1)
        //{
        //    _isRandomSelected = true;
        //    //StartCoroutine(ChangeSkyBox());
        //}
    }

    //IEnumerator ChangeSkyBox()
    //{
    //    _isRandomSelected = false;
    //    while (true)
    //    {
    //        _randomIndex = Random.Range(0, _skyBoxes.Length - 1);

    //        for (int i = 0; i < _skyBoxes.Length; i++)
    //        {
    //            RenderSettings.skybox = _skyBoxes[i];
    //            yield return new WaitForSeconds(_changeDelayTime);

    //        }
    //        //foreach (var skybox in _skyBoxes)
    //        //{
    //        //    RenderSettings.skybox = skybox;

    //        //}

    //        //yield return new WaitForEndOfFrame();

    //    }
    //}

    public void SelectItemInSkyBox(int currentSelection, Material[] childMat)
    {
        if (_isRandomSelected == false)
        {
            RenderSettings.skybox = childMat[currentSelection];
            PlayerPrefs.SetInt("Current Selection", currentSelection);
        }
        
    }
}
