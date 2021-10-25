using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    [SerializeField] Material[] _skyBoxes;
    [SerializeField] float _changeDelayTime = 10f;

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
      //  StartCoroutine(ChangeSkyBox());
    }

    // Update is called once per frame
    void Update()
    {
        var pref = PlayerPrefs.GetInt("Selected SkyBox");
        
        RenderSettings.skybox = _skyBoxes[pref];
        Debug.Log("==>" + pref);
    }

    //IEnumerator ChangeSkyBox()
    //{
    //        while (true)
    //        {
    //            _randomIndex = Random.Range(0, _skyBoxes.Length - 1);

    //            RenderSettings.skybox = _skyBoxes[_randomIndex];
    //            yield return new WaitForSeconds(_changeDelayTime);
    //        }
    //}

    public void SelectItem(int currentSelection, Material[] childMat)
    {
        RenderSettings.skybox = childMat[currentSelection];
        PlayerPrefs.SetInt("Current Selection", currentSelection);
    }
}
