using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton_Build : UIButton, IDragHandler
{
    private Canvas UICanvas = default;
    private Image TowerImage;
    private RectTransform Rect = default;

    public GameObject towerPrefab;


    //private bool isTowerImageOn = false;
    private bool isDragging = false;


    private void Awake()
    {
        var uiCanvas = GameObject.FindGameObjectWithTag("UICanvas");

        UICanvas = uiCanvas.GetComponent<Canvas>();

        //0
        //1~
        TowerImage = GetComponentsInChildren<Image>()[1];
        Rect = TowerImage.GetComponent<RectTransform>();


        isDragging = false;
        TowerImage.gameObject.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            isDragging = false;
            TowerImage.gameObject.SetActive(false);
        }
    }


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

        if (isDragging == false)
        {
            isDragging = true;
            TowerImage.gameObject.SetActive(true);
            Rect.anchoredPosition = new Vector2(0, 0);
            Debug.Log("다운");
        }
        else
        {
            /* Do Nothing */
        }
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (isDragging == true) 
        {
            Rect.anchoredPosition += (eventData.delta / UICanvas.scaleFactor);
            Debug.Log("드래그");
        }
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        base.DoPointerUp(eventData);

        //Vector2 lastMousePos = Vector2.zero;
        //Ray ray = Camera.main.Screen(Input.mousePosition);
        //RaycastHit hit;

        //if()


        if(isDragging == true) 
        {
            isDragging = false;
            TowerImage.gameObject.SetActive(false);
            GameObject obj= Instantiate(towerPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0);
            Debug.Log("업");
        }
        else
        {
            /* Do Nothing */
        }
    }
}
