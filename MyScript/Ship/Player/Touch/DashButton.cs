using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class DashButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Color colorOnHold;
    public Color colorNormal;
    public bool isHolding;

    UnityEngine.UI.Image button_image;
    void Start()
    {
        button_image = GetComponent<UnityEngine.UI.Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        button_image.color = colorOnHold;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        button_image.color = colorNormal;
    }
}
