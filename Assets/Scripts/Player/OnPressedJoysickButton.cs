using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPressedJoysickButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RobotSystem _robotSystem;
    [SerializeField] private float myltiplayTimeDelay = 1;
    [Header("0-право,1-лево")]
    public int index;
    private Vector2[] directions = new Vector2[2] {Vector2.right, Vector2.left };
    private bool pressed = false;
    private bool down = false;
    private float timeDelay;
    public void FingerEnter()
    {
        pressed = true;
    }
    public void FingerExit()
    {
        pressed = false;
        timeDelay = 0;
        _robotSystem.Movement(directions[index], timeDelay);
    }
    public void FingerDown()
    {
        down = true;

    }
    public void FingerUp()
    {
        down = false;
        timeDelay = 0;
        _robotSystem.Movement(directions[index], timeDelay);
    }
    private void Update()
    {
        if (pressed && down)
        {
            timeDelay += myltiplayTimeDelay * Time.deltaTime;
            timeDelay = Mathf.Clamp(timeDelay, 0, 1);
            _robotSystem.Movement(directions[index], timeDelay);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        FingerEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FingerExit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        FingerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FingerUp();
    }
}
