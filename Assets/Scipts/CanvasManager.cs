using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    public CanvasGroup uiElement;
    public float lerpTime=0.5f;
    private IEnumerator FadeCanvas(CanvasGroup cg,float start, float end)
    {
        //время начала, конца и процент выполнения
        var timeStartedLerping = Time.time;

        while (true)
        {
            var timeSinceStarted = Time.time - timeStartedLerping;
            var percentageComplete = timeSinceStarted / lerpTime;
            
            var currentValue = Mathf.Lerp(start, end, percentageComplete);
            //прозрачность
            cg.alpha = currentValue;
            //Конец когда 100%
            if (percentageComplete >= 1) break;
            yield return new WaitForEndOfFrame();
        }
        print("fade done");
    }

    public void FadeIn()
    { 
        EnableInteract(); 
        StartCoroutine(FadeCanvas(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        DisableInteract();
        StartCoroutine(FadeCanvas(uiElement, uiElement.alpha, 0));
    }

    public void Update()
    {
        AutoDeactivateDialogCanvas();
    }
    
    //Автовыключение канваса если был сделан выбор
    private void AutoDeactivateDialogCanvas()
    {
        UIManager.MainCanvas.gameObject.SetActive(uiElement.alpha!=0);
    }
    
    private void DisableInteract()
    {
        uiElement.interactable = false;
        uiElement.blocksRaycasts = false;
    }

    private void EnableInteract()
    {
        uiElement.interactable = true;
        uiElement.blocksRaycasts = true;
    }
}