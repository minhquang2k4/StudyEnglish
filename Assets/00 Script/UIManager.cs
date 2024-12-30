using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button[] homeBtt;
    [SerializeField] Button[] restartBtt;
    [Space] [SerializeField] Button PlayBtt;

    [SerializeField] GameObject Menu;

    void Start()
    {
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
    }

    public void OpenLevel(int level)
    {
        string levelName = "Level" + level;
        SceneManager.LoadScene(levelName);
    }
}