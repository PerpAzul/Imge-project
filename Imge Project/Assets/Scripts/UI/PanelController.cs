using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private  GameObject Panel; //HelpButton
    [SerializeField]
    private  GameObject Options;

    private bool helpIsOpen = false;
    private bool OptionIsOpen = false;
    private void Awake()
    {
        Panel.SetActive(false); //HelpButton
        Options.SetActive(false);
    }

    private void Update()
    {
        //user can click esc to close the windows
        if (Input.GetKeyDown(KeyCode.Escape) && helpIsOpen)
        {
            CloseHelp();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && OptionIsOpen)
        {
            CloseOptions();
        }
    }

    public void LoadHelp()
    {
        Panel.SetActive(true); //HelpButton
        helpIsOpen = true;
    }

    public  void CloseHelp()
    {
        Panel.SetActive(false); //HelpButton
        helpIsOpen = false;
    }
    public void LoadOptions()
    {
        Options.SetActive(true);
        OptionIsOpen = true;
    }
    public void CloseOptions()
    {
        Options.SetActive(false);
        OptionIsOpen = false;
    }
}
