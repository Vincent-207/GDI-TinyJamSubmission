using System.Collections.Specialized;
using UnityEngine;

public class putInCorner : MonoBehaviour
{

    RectTransform rectTransform;
    [SerializeField]
    Vector3 placePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 anchoredPos = Vector3.zero;
        
        anchoredPos.x =  placePos.x * rectTransform.localScale.x;
        anchoredPos.y =  placePos.y * rectTransform.localScale.y;
        anchoredPos.z =  placePos.z * rectTransform.localScale.z;
        rectTransform.anchoredPosition = anchoredPos;
    }
}
