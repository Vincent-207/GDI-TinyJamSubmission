using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static int Quota = 6;
    public static int baseQuota = 6;
    static string quotaSaveKey = "Quota";
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
        Quota = baseQuota;
    }
    public void saveHighestQuota()
    {
        
        if(!PlayerPrefs.HasKey(quotaSaveKey))
        {
            PlayerPrefs.SetInt(quotaSaveKey, Quota);
        }
        else
        {
            int currentHighScore = PlayerPrefs.GetInt(quotaSaveKey, baseQuota);
            if(currentHighScore < Quota)
            {
                PlayerPrefs.SetInt(quotaSaveKey, Quota);
            }
        }
    }

    public int getHighestQuota()
    {
        return 0;
    }
}
