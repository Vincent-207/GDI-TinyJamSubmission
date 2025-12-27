using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core;
using UnityEngine;

public class ClipBoardTweenHandler : MonoBehaviour
{
    [SerializeField]
    putInCorner putInCornerScript;
    public List<Tween> tweens;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    /* void Update()
    {
        tweens = DOTween.TweensByTarget(this, true );
        if(tweens != null)
        {
            Debug.Break();
        }
        if( tweens != null)
        {
            putInCornerScript.enabled = false;
        }
        else
        {
            putInCornerScript.enabled = true;
        }
    } */
    public void toggleComponent()
    {
        if(putInCornerScript.enabled)
        {
            putInCornerScript.enabled = false;
            
        }
        else
        {
            Debug.Log("Doing it!");
            // Debug.Break();
        }
        
        // Debug.Break();
    }

    public void Enable()
    {
        putInCornerScript.enabled = true;
    }

    public void Disable()
    {
         putInCornerScript.enabled = false;
    }
}
