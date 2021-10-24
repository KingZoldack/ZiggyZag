using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectorScroller : MonoBehaviour
{
    [SerializeField] Button previousButton;
    [SerializeField] Button nextButton;
    [SerializeField] Material[] skyBoxMaterials;
    [SerializeField] TextMeshProUGUI itemNameText;

    [SerializeField] SkyBoxManager skyBoxManager;

    int currentItem;

    private void Awake()
    {
        SelectItem(0);
        itemNameText.text = transform.GetChild(0).name;
        //skyBoxManager = FindObjectOfType<SkyBoxManager>();

    }

    private void Update()
    {
        //SelectSkyBox();
    }

    

    void SelectItem(int _selectedIndex)
    {
        previousButton.interactable = (_selectedIndex != 0);
        nextButton.interactable = (_selectedIndex != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _selectedIndex);
        }
    }

    public void ChangeItem(int _change)
    {
        currentItem += _change;
        itemNameText.text = transform.GetChild(currentItem).name;
        SelectItem(currentItem);
    }

    public void SelectSkyBox()
    {
        skyBoxManager.SelectItem(currentItem, skyBoxMaterials);
        PlayerPrefs.SetInt("SkyBox", currentItem);
        Debug.Log(currentItem + "<=== CurrentItem");

    }



}
