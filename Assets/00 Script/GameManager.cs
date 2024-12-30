using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> checkAws = new List<GameObject>();
    public bool result;
    public GameObject Win;
    public GameObject Lose;
    private int filledSlots;

    private void Awake()
    {
        result = true;
    }

    public void CheckWord()
    {
        foreach (var aw in checkAws)
        {
            if (!aw.GetComponent<ItemSlot>().isCorrect)
            {
                result = false;
                break;
            }
        }

        if (result)
        {
            Win.gameObject.SetActive(true);
        }
        else
        {
            Lose.gameObject.SetActive(true);
        }
    }
    
}
