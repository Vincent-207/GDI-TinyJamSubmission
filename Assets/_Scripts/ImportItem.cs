using System;
using UnityEngine;

public class ImportItem : MonoBehaviour
{
    public ClipboardInfo clipboardInfo;
    [SerializeField]
    ItemInfo itemInfo;
    public GameObject threadsImage;
    public bool shouldBePassed;
    // DEBUG
    // public ClipBoard clipBoard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // DEBUG - clipBoard.updateClipBoard(clipboardInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ImportValues(ClipboardInfo clipboardInfo, ItemInfo itemInfo, GameObject threadsImage, bool shouldBePassed)
    {
        this.clipboardInfo = clipboardInfo;
        this.itemInfo = itemInfo;
        this.threadsImage = threadsImage;
        this.shouldBePassed = shouldBePassed;
    }
}
[Serializable]
public class ItemInfo
{
    public int SerialNumber;
    public StitchType stitchType;

    public ItemInfo(int sn, StitchType stitchType)
    {
        SerialNumber = sn;
        this.stitchType = stitchType;
    }

}
[Serializable]
public class ClipboardInfo
{
    public int SerialNumber;
    public StitchType stitchType;
    public ClipboardInfo(int sn, StitchType stitchType)
    {
        SerialNumber = sn;
        this.stitchType = stitchType;
    }
    public String toString()
    {
        return "SN: " + SerialNumber.ToString("000") +  "\nStitch type: " + Enum.GetName(typeof(StitchType), stitchType);
    }
}
[Serializable]
public enum StitchType
{
    Horizontal,
    Vertical,
    Diagonal,
}