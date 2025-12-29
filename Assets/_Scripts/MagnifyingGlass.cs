using UnityEngine;
using UnityEngine.InputSystem;

public class MagnifyingGlass : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isPickedUp = false;
    Vector3 placePos;
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
            
        }

        
    }

    void returnItem()
    {
        rectTransform.anchoredPosition = placePos;
    }
    void Start()
    {
       rectTransform = GetComponent<RectTransform>(); 
       placePos = rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPickedUp)
        {
            // Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 mousePos = Mouse.current.position.ReadValue();
            rectTransform.position = mousePos;
        }
    }
}
