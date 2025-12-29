using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class StaticRectTransformChild : StaticChild
{
    [SerializeField]
        
    RectTransform targetRectTransform;
    RectTransform myRectTransform;
    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        myRectTransform.position = targetRectTransform.position;
    }
}
