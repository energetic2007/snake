using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] Snake snakeInstance;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                Debug.Log("Right");
                snakeInstance.Right();
            }
            else
            {
                Debug.Log("Left");
                snakeInstance.Left();
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                Debug.Log("Up");
                snakeInstance.Up();
            }
            else
            {
                snakeInstance.Down();
            }
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {

    }
}