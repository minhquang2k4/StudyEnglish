using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button[] homeBtt;
    [SerializeField] Button[] restartBtt;
    
    void Start()
    {
        foreach (var home in homeBtt)
        {
            home.onClick.AddListener(() => { SceneManager.LoadScene("Home"); });

        }

        foreach (var res in restartBtt)
        {
            res.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);});

        }
    }

}
