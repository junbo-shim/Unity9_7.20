using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton_Play : UIButton
{
    public GameObject pauseButton;


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
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
    }
}
