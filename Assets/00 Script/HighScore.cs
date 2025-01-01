using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] Text Name;   
    [SerializeField] Text highScoreText;

    private void Update()
    {
        Name.text = PlayerPrefs.GetString("NAME") + " :";
        highScoreText.text = PlayerPrefs.GetInt("HIGHSCORE").ToString();
    }
}
