using System.Collections.Specialized;
using UnityEngine;

public class putInCorner : MonoBehaviour
{

    RectTransform rectTransform;
    public Vector3 placePos, leavePos, enterPos;
    public bool updatePosition = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(updatePosition)
        {
            Vector3 anchoredPos = Vector3.zero;
            
            anchoredPos.x =  placePos.x * rectTransform.localScale.x;
            anchoredPos.y =  placePos.y * rectTransform.localScale.y;
            anchoredPos.z =  placePos.z * rectTransform.localScale.z;
            rectTransform.anchoredPosition = anchoredPos;
            
        }
        enterPos = new Vector3(placePos.x * rectTransform.localScale.x, placePos.y * rectTransform.localScale.y, placePos.z * rectTransform.localScale.z);
        leavePos = enterPos;
        leavePos.y *= -1;
    }
}
