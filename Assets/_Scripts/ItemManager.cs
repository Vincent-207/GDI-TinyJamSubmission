using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;
public class ItemManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject[] ItemQueue;
    public bool[] correctChoices;
    public GameObject currentItem;
    int currentItemIndex = 0;
    public Canvas canvas;
    public RectTransform itemRect, clipBoardRect;
    public putInCorner putInCornerScript;
    [SerializeField]
    Vector3 itemPassLeavePos, itemFailLeavePos, clipboardLeavePos, itemEnterPos, clipboardEnterPos;
    public float fadeTime = 1;
    
    public Transform magnifyingGlassTransform;
    public Transform magnifiyingGlassHandle;
    public TMP_Text quotaTMP_Text;

    public List<bool> choices;
    public int quotaRequirment;

    public float roundTimerDuration;
    public float currentRoundTimerDuration;
    public TMP_Text timerTMP_Text;
    public ShirtPrefabGen shirtPrefabGen;
    void Start()
    {
        currentRoundTimerDuration = roundTimerDuration;
        choices = new List<bool>();
        correctChoices = new bool[quotaRequirment];
        ItemQueue = new GameObject[quotaRequirment];
        for(int i = 0; i < quotaRequirment; i++)
        {
            ItemQueue[i] = shirtPrefabGen.Generate();
            correctChoices[i] = ItemQueue[i].GetComponent<ImportItem>().shouldBePassed;
        }
        
        // choices.Add(passOldItem);
        quotaTMP_Text.text = "Quota: " + choices.Count + " / " + quotaRequirment;
        
        // currentItemIndex++;
        //  true : false
        // Vector3 outPos = passOldItem ? itemPassLeavePos : itemFailLeavePos;
        
        Tween itemTween = itemRect.DOAnchorPos(Vector3.zero, fadeTime, false).SetEase(Ease.OutQuart);
        Tween clipBoardTween = clipBoardRect.DOAnchorPos(putInCornerScript.leavePos, fadeTime, false).SetEase(Ease.OutQuart);

        StartCoroutine(tweenNewItem(itemTween));
        StartCoroutine(tweenNewClipboard(clipBoardTween));
        magnifiyingGlassHandle.SetAsLastSibling();
    }

    void Update()

    {
        currentRoundTimerDuration -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentRoundTimerDuration / 60F);
        int seconds = Mathf.FloorToInt(currentRoundTimerDuration - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerTMP_Text.text = niceTime;
        if(currentRoundTimerDuration <= 0)
        {
            EndRound();
        }
    }
    public void loadNewItem(bool passOldItem)
    {
        choices.Add(passOldItem);
        quotaTMP_Text.text = "Quota: " + choices.Count + " / " + quotaRequirment;
        if(choices.Count >= quotaRequirment)
        {
            EndRound();
            return;
        }
        currentItemIndex++;
        //  true : false
        Vector3 outPos = passOldItem ? itemPassLeavePos : itemFailLeavePos;
        
        Tween itemTween = itemRect.DOAnchorPos(outPos, fadeTime, false).SetEase(Ease.OutQuart);
        Tween clipBoardTween = clipBoardRect.DOAnchorPos(putInCornerScript.leavePos, fadeTime, false).SetEase(Ease.OutQuart);

        StartCoroutine(tweenNewItem(itemTween));
        StartCoroutine(tweenNewClipboard(clipBoardTween));
    }

    void EndRound()
    {
        if(choices.Count < quotaRequirment)
        {
            // GAME OVER - Didn't meet quota. 
            Debug.Log("Didn't meet quota.");
        }
        else if(CompareChoices() == false)
        {
            Debug.Log("GAME OVER. selected wrong!");
        }
        else
        {
            Debug.Log("You WON!");
        }
    
        Debug.Break();
    }
    bool CompareChoices()
    {
        bool output = true;
        for(int i = 0; i < quotaRequirment; i++)
        {
            if(choices[i] != correctChoices[i])
            {
                return false;
            }
        }

        return output;
    }
    IEnumerator tweenNewClipboard(Tween clipboardTween)
    {
        putInCornerScript.updatePosition = false;
        // yield return new WaitForSeconds(1);
        DestroyAllChildren(magnifyingGlassTransform);
        while(clipboardTween.IsPlaying())
        {
            yield return null;
        }
        // Debug.Break(); 
        clipBoardRect.anchoredPosition = clipboardLeavePos;
        
        Tween clipboardEnterTween = clipBoardRect.DOAnchorPos(putInCornerScript.enterPos, 1, false).SetEase(Ease.OutCubic);
        while(clipboardEnterTween.IsPlaying())
        {
            yield return null;
        }
        putInCornerScript.updatePosition = true;

        
    }
    IEnumerator tweenNewItem(Tween itemTween)
    {
        // wait for exit tween to finish.
        while(itemTween.IsPlaying())
        {
            yield return null;
        }

        // handle old Items
        if(itemRect != null)
        {
            Destroy(itemRect.gameObject);
            
        }
        // Debug.Log("Done!");


        // Create and setup new item.
        currentItem = Instantiate(ItemQueue[currentItemIndex], Vector3.zero, Quaternion.identity, canvas.transform);
        RectTransform currentItemRectTransform = currentItem.GetComponent<RectTransform>();
        currentItemRectTransform.anchoredPosition = itemEnterPos;
        Tween newItemTween = currentItemRectTransform.DOAnchorPos(Vector2.zero, 1, false).SetEase(Ease.InCubic);
        itemRect = currentItemRectTransform;




        // load data to clipboard.
        ImportItem importItem = currentItem.GetComponent<ImportItem>();
        loadData(importItem);
        
        
        Image threadsImage = importItem.threadsImage.GetComponent<Image>();
        threadsImage.enabled = false;
        // Debug.Break();

        while(newItemTween.IsPlaying())
        {
            yield return null;
        }

        threadsImage.enabled = true;
        
        threadsImage.transform.SetParent(magnifyingGlassTransform, true);
        StaticChild threadsStaticChild = threadsImage.GetComponent<StaticChild>();
        threadsStaticChild.position = threadsImage.transform.position;
        threadsStaticChild.DoUpdate = true;
        magnifiyingGlassHandle.SetAsLastSibling();
    }

    void loadData(ImportItem importItem)
    {
        if(importItem == null)
        {
            Debug.LogError("IMPORT ITEM COULDN't be found");
            Debug.Break();
        }

        clipBoardRect.GetComponent<ClipBoard>().updateClipBoard(importItem);
        // update stitching mask.
        importItem.threadsImage.GetComponent<Image>().enabled = true;
    }

    void DestroyAllChildren(Transform target)
    {
        int childCount = target.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Destroy(target.GetChild(0).gameObject);
        }
    }

}
