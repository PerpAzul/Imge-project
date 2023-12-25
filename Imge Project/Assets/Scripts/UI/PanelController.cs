using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private  GameObject Panel;
    
    private void Awake()
    {
        Panel.SetActive(false);
    }

    public void LoadHelp()
    {
        Panel.SetActive(true);
    }

    public  void Close()
    {
        Panel.SetActive(false);
    }
}
