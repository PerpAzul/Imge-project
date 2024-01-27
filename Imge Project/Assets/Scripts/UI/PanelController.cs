using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    //private GameObject MainMenu;
    [SerializeField]
    private  GameObject Panel; //HelpButton
    [SerializeField]
    private  GameObject Options;
    
    private void Awake()
    {
        Panel.SetActive(false); //HelpButton
        Options.SetActive(false);
    }

    public void LoadHelp()
    {
        Panel.SetActive(true); //HelpButton
    }

    public  void Close()
    {
        Panel.SetActive(false); //HelpButton
    }
    public void LoadOptions()
    {
        Options.SetActive(true);
        //SceneManager.LoadScene("OptionsScreenScene");
    }
    public void CloseOptions()
    {
        Options.SetActive(false);
    }
}
