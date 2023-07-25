using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton_Pause : UIButton
{
    public GameObject playButton;


    protected override void DoPointerEnter(PointerEventData eventData)
    {
        base.DoPointerEnter(eventData);

    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        base.DoPointerExit(eventData);

    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        base.DoPointerDown(eventData);

    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        base.DoPointerUp(eventData);

        gameObject.SetActive(false);
        Time.timeScale = 0f;
        playButton.SetActive(true);
    }
}
