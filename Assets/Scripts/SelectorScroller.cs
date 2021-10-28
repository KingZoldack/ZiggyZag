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
        var loadSelectedSkyBoxText = PlayerPrefs.GetInt("Selected SkyBox");

        SelectItem(0);
        itemNameText.text = transform.GetChild(0).name;
        transform.GetChild(loadSelectedSkyBoxText).GetChild(1).gameObject.SetActive(true);
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
        skyBoxManager.SelectItemInSkyBox(currentItem, skyBoxMaterials);
        PlayerPrefs.SetInt("Selected SkyBox", currentItem);
        transform.GetChild(currentItem).GetChild(1).gameObject.SetActive(true);
    }
}
