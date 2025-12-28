

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShirtPrefabGen : MonoBehaviour
{

    public Canvas canvas;
    public GameObject shirtPrefab;
    GameObject newShirt;
    public Sprite[] shirtPool;
    public Sprite[] stitchPool;
    public ClipboardInfo clipboardInfo;
    public ItemInfo itemInfo;
    [Range(0, 1f)]
    public float shouldBePassedPercent;
    public bool generatedIsPassable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // generatedIsPassable = Random.Range(0, 1f) <= shouldBePassedPercent;
        // Generate(generatedIsPassable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Generate()
    {
        return Generate(generatedIsPassable = Random.Range(0, 1f) <= shouldBePassedPercent);
    }
    public GameObject Generate(bool shouldBePassed)
    {
        // Generate values
        Sprite selectedShirtImg = shirtPool[Random.Range(0, shirtPool.Length)];

        int selectedStitchTypeValue = Random.Range(0, System.Enum.GetValues(typeof(StitchType)).Length);
        StitchType selectedStitchType = (StitchType) selectedStitchTypeValue;
        Sprite selectedStitchSprite = stitchPool[selectedStitchTypeValue];
        
        int serialNumber = Random.Range(1, 999);
        itemInfo = new ItemInfo(serialNumber, selectedStitchType);

        // Create objs
        Vector3 hidePos = Vector3.one * 100000;
        newShirt = Instantiate(shirtPrefab, hidePos, Quaternion.identity, transform);
        Image shirtImg =  newShirt.GetComponent<Image>();
        shirtImg.sprite = selectedShirtImg;
        Image stitchesImg = newShirt.transform.GetChild(0).GetComponent<Image>();
        stitchesImg.sprite = selectedStitchSprite;
        TMP_Text snText = newShirt.GetComponentInChildren<TMP_Text>();


        snText.text = serialNumber.ToString("000");


        // update if should be passed or not. 
        if(shouldBePassed)
        {
            clipboardInfo = new ClipboardInfo(serialNumber, selectedStitchType);

        }
        else
        {
            int clipBoardSN= serialNumber;
            StitchType clipboardStitchType = selectedStitchType;
            bool hasFalseSN = Random.Range(0, 2) == 0 ? true : false;
            bool hasFalseStitches = Random.Range(0, 2) == 0 ? true : false;
            bool hasBothFalse = (hasFalseSN == hasFalseStitches) ? true : false;
            // Generate false sn only 25%, false stitches only 25%, and both false 50%
            Debug.Log("both false: " + hasBothFalse);
            Debug.Log("sn false: " + hasFalseSN);
            Debug.Log("stitch false: " + hasFalseStitches);
            if(hasBothFalse || hasFalseSN)
            {
                clipBoardSN  = Random.Range(1, 999);
            }
            if(hasBothFalse || hasFalseStitches)
            {
               clipboardStitchType = (StitchType) Random.Range(0, System.Enum.GetValues(typeof(StitchType)).Length);
            }

            clipboardInfo = new ClipboardInfo(clipBoardSN, clipboardStitchType);
        }

        
        ImportItem importItem = newShirt.GetComponent<ImportItem>();
        importItem.ImportValues(clipboardInfo, itemInfo, stitchesImg.gameObject, shouldBePassed);

        return newShirt;
    }

}
