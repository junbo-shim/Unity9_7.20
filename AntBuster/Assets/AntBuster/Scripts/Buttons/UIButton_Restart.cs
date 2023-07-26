using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIButton_Restart : UIButton
{
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

        SceneManager.LoadScene(gameObject.scene.name);
    }
}
