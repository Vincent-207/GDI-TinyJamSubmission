using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] TMP_Text infoText;
    [SerializeField] Image icon;
    ImportItem currentItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void updateClipBoard(ImportItem newItem)
    {
        currentItem = newItem;
        icon.sprite = currentItem.threadsImage.transform.parent.GetComponent<Image>().sprite;
        infoText.text = "Info\n" + currentItem.clipboardInfo.toString();
    }
}
