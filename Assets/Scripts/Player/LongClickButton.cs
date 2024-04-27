using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onLongClick;
    private bool IsButtonPressed = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        IsButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsButtonPressed = false;
    }

    private void Update()
    {
        if (IsButtonPressed)
        {
            onLongClick?.Invoke();
        }
    }

}
