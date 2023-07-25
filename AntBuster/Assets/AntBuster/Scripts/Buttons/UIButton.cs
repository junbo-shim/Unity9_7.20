using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.DoPointerEnter(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.DoPointerExit(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.DoPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.DoPointerUp(eventData);
    }



    protected virtual void DoPointerEnter(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */
        //Debug.Log("마우스가 올려져 있다.");
        Image image = GetComponent<Image>();
        image.color = Color.gray;
    }

    protected virtual void DoPointerExit(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */
        //Debug.Log("마우스가 벗어났다.");
        Image image = GetComponent<Image>();
        image.color = Color.white;
    }

    protected virtual void DoPointerDown(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */
        //Debug.Log("마우스로 클릭을 하고 있다.");
        Image image = GetComponent<Image>();
        image.color = Color.yellow;
    }

    protected virtual void DoPointerUp(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */
        //Debug.Log("마우스로 클릭을 하고 있다.");
        Image image = GetComponent<Image>();
        image.color = Color.white;
    }
}
