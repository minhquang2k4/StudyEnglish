using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string letter;
    public bool isCorrect;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.gameObject.transform.SetParent(transform);
            if (eventData.pointerDrag.GetComponent<Letter>() != null)
            {
                if (eventData.pointerDrag.GetComponent<Letter>().letter == letter)
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                }
            }
            else
            {
                isCorrect = false;
            }
        }

        Debug.Log("OnDrop");
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            isCorrect = false;
        }
    }
}