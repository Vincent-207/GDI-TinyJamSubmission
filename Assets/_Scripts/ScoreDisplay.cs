using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       GetComponent<TMP_Text>().text = "Highest Round: " + (((DifficultyManager.Quota - DifficultyManager.baseQuota)/2) + 1).ToString();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
