using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public List<GameObject> checkAws = new List<GameObject>();
    public bool result;
    public GameObject Win;
    public GameObject Lose;
    private int filledSlots;
    [Space]
    [SerializeField] static int Score= 0;
    [SerializeField] static int highscore= 0;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        result = true;
        instance = this;
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
            StartCoroutine(UIManager.Instance.LoadScene(Win, true));
            Score++;
            scoreText.text = "Score: " + Score;
            if (Score > highscore)
            {
                highscore = Score;
                PlayerPrefs.SetInt("HIGHSCORE", highscore);
            }
        }
        else
        {
            StartCoroutine(UIManager.Instance.LoadScene(Lose, true));

        }
    }
    
}
