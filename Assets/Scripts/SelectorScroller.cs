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
    bool isSelected;

    private void Awake()
    {
        var loadSelectedSkyBoxText = PlayerPrefs.GetInt(Tags.GET_SELECTED_SKYBOX_TAG); // Loads "Selected" text of the selected skybox.

        //Load first skybox as well as it's name and the "Selected" text:
        SelectItem(0);
        itemNameText.text = transform.GetChild(0).name;
        transform.GetChild(loadSelectedSkyBoxText).GetChild(1).gameObject.SetActive(true);
    }

    void SelectItem(int _selectedIndex) //Loop cycles through the children of attached game object, activating the one it's currently on.
    {
        previousButton.interactable = (_selectedIndex != 0); //Disables previous button when player is at the first background.
        nextButton.interactable = (_selectedIndex != transform.childCount - 1); //Disables next button when player is at the last background.

        for (int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(i == _selectedIndex);
        }
    }

    public void ChangeItem(int _change) //Increments or decrement based on the value set in the inspector (+1 or -1). Attached to buttons Next and previous.
    {
        currentItem += _change;
        itemNameText.text = transform.GetChild(currentItem).name;
        SelectItem(currentItem);
    }

    public void SelectSkyBox()
    {
        isSelected = true;
        skyBoxManager.SelectItemInSkyBox(currentItem, skyBoxMaterials); //Sets SkyBox.
        PlayerPrefs.SetInt(Tags.GET_SELECTED_SKYBOX_TAG, currentItem); //Saves SkyBox selection.

        if (isSelected)
        {
            transform.GetChild(currentItem).GetChild(1).gameObject.SetActive(true); //Actives selected text gameobject
            isSelected = false;

            if (isSelected == false)
            {
                for (int i = 0; i < transform.childCount; i++) //cycles through all selected text gameobjects and set the ones which aren't selected to false.
                {
                    if (i != currentItem)
                    {
                        transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
