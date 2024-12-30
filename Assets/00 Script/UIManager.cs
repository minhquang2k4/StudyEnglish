using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button[] homeBtt;
    [SerializeField] Button[] restartBtt;
    [SerializeField] Button NextBtt;
    [SerializeField] Button PlayBtt;

    [SerializeField] GameObject Menu;

    void Start()
    {
        if(NextBtt != null)
            NextBtt.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); });
        if (PlayBtt != null)
            PlayBtt.onClick.AddListener(() => { Menu.SetActive(true); });
        foreach (var home in homeBtt)
        {
            home.onClick.AddListener(() =>
            {
                if (Menu != null && Menu.activeSelf)
                {
                    Menu.SetActive(false);
                }

                SceneManager.LoadScene("Home");
            });
        }

        foreach (var res in restartBtt)
        {
            res.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        }
        //if (NextBtt != null)
        //  NextBtt.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); });
    }

    public void OpenLevel(int level)
    {
        string levelName = "Level" + level;
        SceneManager.LoadScene(levelName);
    }

    // public void NextLevel()
    // {
    //     int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    //     if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    //     {
    //         SceneManager.LoadScene(nextSceneIndex);
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Next scene index is out of range.");
    //     }
    // }
}