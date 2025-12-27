using Unity.Mathematics;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    bool isZoomedIn = false;
    [SerializeField]
    float tweenDuration;
    [SerializeField]
    AnimationCurve growCurve, lessenCurve;
    float currentTweenTime;
    void Start()
    {
        currentTweenTime = tweenDuration;
    }
    public void toggleZoom()
    {
        // if in tween, reset time correctly. 
        if(currentTweenTime < tweenDuration)
        {
            currentTweenTime = 1 - currentTweenTime;
        }
        else
        {
        currentTweenTime = 0;
            
        }
        isZoomedIn = !isZoomedIn;
    }

    void Update()
    {
        currentTweenTime += Time.deltaTime;
        float normalizedTimePos = math.min(currentTweenTime / tweenDuration, 1f);
        if(isZoomedIn)
        {
            transform.localScale = Vector3.one * growCurve.Evaluate(normalizedTimePos);
        }
        else
        {
            transform.localScale = Vector3.one * lessenCurve.Evaluate(normalizedTimePos);
            
        }
        
    }
}
