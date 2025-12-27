using System;
using TMPro;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] TMP_Text infoText;
    ImportItem currentItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void updateClipBoard(ImportItem newItem)
    {
        currentItem = newItem;
        infoText.text = "Info\n" + currentItem.clipboardInfo.toString();
    }
}
