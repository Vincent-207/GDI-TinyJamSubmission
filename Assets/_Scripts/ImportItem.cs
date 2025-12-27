using System;
using UnityEngine;

public class ImportItem : MonoBehaviour
{
    [SerializeField]
    ClipboardInfo clipboardInfo;
    [SerializeField]
    ItemInfo itemInfo;
    public GameObject threadsImage;
    // DEBUG
    public ClipBoard clipBoard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clipBoard.updateClipBoard(clipboardInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoImport()
    {
        
    }
}
[Serializable]
public class ItemInfo
{
    public int SerialNumber;
    public StitchType stitchType;

}
[Serializable]
public class ClipboardInfo
{
    public int SerialNumber;
    public StitchType stitchType;
    public String toString()
    {
        return "SN: " + SerialNumber.ToString() +  "\nStitch type: " + Enum.GetName(typeof(StitchType), stitchType);
    }
}
[Serializable]
public enum StitchType
{
    Horizontal,
    Vertical,
    Diagonal,
}