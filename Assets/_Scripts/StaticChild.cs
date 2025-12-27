using UnityEngine;

public class StaticChild : MonoBehaviour
{
    public bool DoUpdate;
    public Vector3 position;
    void Update()
    {
        if(DoUpdate)
        {
            transform.position = position;
            
        }
    }
}
