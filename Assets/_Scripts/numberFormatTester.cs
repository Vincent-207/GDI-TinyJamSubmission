using TMPro;
using UnityEngine;

public class numberFormatTester : MonoBehaviour
{
    [SerializeField] TMP_Text tMP_Text;
    public int num ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tMP_Text.text = num.ToString("000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
