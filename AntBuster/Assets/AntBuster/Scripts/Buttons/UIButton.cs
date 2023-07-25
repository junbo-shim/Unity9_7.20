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
        /* Override �޾Ƽ� ����Ѵ�. */
        //Debug.Log("���콺�� �÷��� �ִ�.");
        Image image = GetComponent<Image>();
        image.color = Color.gray;
    }

    protected virtual void DoPointerExit(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */
        //Debug.Log("���콺�� �����.");
        Image image = GetComponent<Image>();
        image.color = Color.white;
    }

    protected virtual void DoPointerDown(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */
        //Debug.Log("���콺�� Ŭ���� �ϰ� �ִ�.");
        Image image = GetComponent<Image>();
        image.color = Color.yellow;
    }

    protected virtual void DoPointerUp(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */
        //Debug.Log("���콺�� Ŭ���� �ϰ� �ִ�.");
        Image image = GetComponent<Image>();
        image.color = Color.white;
    }
}
