using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Savename : MonoBehaviour
{
    [SerializeField] private InputField name;
    [SerializeField] Button Ok;
    [SerializeField] private GameObject Level;
    
    void Start()
    {
        Ok.onClick.AddListener(() =>
        {
            PlayerPrefs.SetString("NAME", name.text);
            if(name.text != "")
            {
                Level.gameObject.SetActive(true);
            }
        });
        
    }

}
