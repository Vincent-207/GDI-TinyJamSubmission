using UnityEngine;

public class maskTest : MonoBehaviour
{
    [SerializeField]
    GameObject childImage;
    Vector3 childImagePos;
    RectTransform childRectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childRectTransform = childImage.GetComponent<RectTransform>();
        childImagePos = childRectTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        childRectTransform.position = childImagePos;
    }
}
