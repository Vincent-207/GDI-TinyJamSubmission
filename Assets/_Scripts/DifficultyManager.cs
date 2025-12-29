using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static int Quota;
    static int baseQuota = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseQuota()
    {
        Quota += 2;
    }
    public void resetQuota()
    {
        
    }
}
