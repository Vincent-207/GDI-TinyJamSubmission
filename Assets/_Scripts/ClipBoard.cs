using System;
using TMPro;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] TMP_Text infoText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void updateClipBoard(ClipboardInfo clipboardInfo)
    {
        infoText.text = "Info\n" + clipboardInfo.toString();
    }
}
