using UnityEngine;
using UnityEngine.InputSystem;

public class MagnifyingGlass : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isPickedUp = false;
    Vector3 placePos;
    Vector3 stitchesPos;
    [SerializeField]
    RectTransform stitchesRectTransform;
    RectTransform rectTransform;
    public void toggleEquip()
    {
        isPickedUp = !isPickedUp;
        if(!isPickedUp)
        {
            // if putting down, return item.
            returnItem();
        }
        else
        {
            stitchesPos = stitchesRectTransform.position;
            
        }

        
    }

    void returnItem()
    {
        rectTransform.position = placePos;
        stitchesRectTransform.position = stitchesPos;
    }
    void Start()
    {
       rectTransform = GetComponent<RectTransform>(); 
       placePos = rectTransform.position;
       stitchesPos = stitchesRectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        stitchesRectTransform.position = stitchesPos;
        if(isPickedUp)
        {
            // Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 mousePos = Mouse.current.position.ReadValue();
            rectTransform.position = mousePos;
        }
    }
}
