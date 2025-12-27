using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
public class ItemManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] Items;
    public GameObject currentItem;
    int currentItemIndex = 0;
    public Canvas canvas;
    public RectTransform itemRect, clipBoardRect;
    public putInCorner putInCornerScript;
    [SerializeField]
    Vector3 itemPassLeavePos, itemFailLeavePos, clipboardLeavePos, itemEnterPos, clipboardEnterPos;
    public float fadeTime = 1;
    public void loadNewItem(bool passOldItem)
    {
        
        currentItemIndex++;
        if(currentItemIndex == Items.Length)
        {
            // TODO/DEBUG needs to end round. only restarting for testing.
            currentItemIndex = 0;
        }
        //  true : false
        Vector3 outPos = passOldItem ? itemPassLeavePos : itemFailLeavePos;
        
        Tween itemTween = itemRect.DOAnchorPos(outPos, fadeTime, false).SetEase(Ease.OutQuart);
        Tween clipBoardTween = clipBoardRect.DOAnchorPos(putInCornerScript.leavePos, fadeTime, false).SetEase(Ease.OutQuart);

        // while(clipBoardTween.IsPlaying());
        // 
        StartCoroutine(tweenNewItem(itemTween));
        StartCoroutine(tweenNewClipboard(clipBoardTween));
    }
    IEnumerator tweenNewClipboard(Tween clipboardTween)
    {
        putInCornerScript.updatePosition = false;
        // yield return new WaitForSeconds(1);
        
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
        while(itemTween.IsPlaying())
        {
            yield return null;
        }
        Debug.Log("Done!");
        // tween item
        currentItem = Instantiate(Items[currentItemIndex], Vector3.zero, Quaternion.identity, canvas.transform);
        RectTransform currentItemRectTransform = currentItem.GetComponent<RectTransform>();
        currentItemRectTransform.anchoredPosition = itemEnterPos;
        currentItemRectTransform.DOAnchorPos(Vector2.zero, 1, false).SetEase(Ease.InCubic);
        itemRect = currentItemRectTransform;
    }

}
