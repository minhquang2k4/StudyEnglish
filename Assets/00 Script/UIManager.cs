using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;
    [SerializeField] Button[] homeBtt;
    [SerializeField] Button[] restartBtt;
    [Space] [SerializeField] Button NextBtt;
    [SerializeField] Button PlayBtt;
    [SerializeField] Button _HighScoreBtt;
    [SerializeField] GameObject highScore;
    [Space] [SerializeField] GameObject Menu;
    [Space] [SerializeField] Animator Anim;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (NextBtt != null)
            NextBtt.onClick.AddListener(() =>
            {
                StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
            });
        if (PlayBtt != null)
            PlayBtt.onClick.AddListener(() => { StartCoroutine(LoadScene(Menu, true)); });

        foreach (var home in homeBtt)
        {
            home.onClick.AddListener(() =>
            {
                if (SceneManager.GetActiveScene().name == "Home")
                {
                    if (Menu != null && Menu.activeSelf)
                    {
                        StartCoroutine(LoadScene(Menu, false));
                    }
                    if(highScore != null && highScore.activeSelf)
                    {
                        StartCoroutine(LoadScene(highScore, false));
                    }
                }
                else
                {
                    StartCoroutine(LoadScene("Home"));
                }
            });
        }

        foreach (var res in restartBtt)
        {
            res.onClick.AddListener(() => { StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex)); });
        }

        if (_HighScoreBtt != null)
        {
            _HighScoreBtt.onClick.AddListener(() => { StartCoroutine(LoadScene(highScore, true)); });

        }
    }
    
    public void OpenLevel(int level)
    {
        string levelName = "Level" + level;
        StartCoroutine(LoadScene(levelName));
    }

    public IEnumerator LoadScene(GameObject tager, bool On)
    {
        Anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        if (On)
        {
            tager.SetActive(true);
        }
        else
        {
            tager.SetActive(false);
        }

        Anim.SetTrigger("Start");
    }

    IEnumerator LoadScene(int tager)
    {
        Anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(tager);
        Anim.SetTrigger("Start");
    }

    IEnumerator LoadScene(string tager)
    {
        Anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(tager);
        Anim.SetTrigger("Start");
    }
}