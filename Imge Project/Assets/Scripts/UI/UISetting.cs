using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    //sensitivity UI Text
    public TextMeshProUGUI SensitivityText;
    public TextMeshProUGUI VolumeText;
    public TextMeshProUGUI ResolutionText;
    public Slider s;
    public Slider s_v;
    public Toggle fs_t;
    private struct res {
        public int width;
        public int height;
    }
    private res[] Resolutions = new res[3];
    private int selectedResolution = 1;
    // Update is called once per frame
    private void Awake()
    {
        fs_t.isOn = Screen.fullScreen;
        Resolutions[0].width    = 1280;
        Resolutions[0].height   =  720;
        Resolutions[1].width    = 1920;
        Resolutions[1].height   = 1080;
        Resolutions[2].width    = 2560;
        Resolutions[2].height   = 1440; 
    }

    void Update()
    {
        SensitivityText.text = PlayerLook.sensitivityScale.ToString("0.##");
        VolumeText.text = (100 * Player.volume).ToString("###");
    }
    public void changeSensitivity(float value)
    {
        PlayerLook.sensitivityScale = value;
    }
    public void changeVolume(float value)
    {
        Player.volume = value;
        PlayerHealth.volume = value;
        Shooting.volume = value;
        Enemy.volume = value;
        PlayerInteract.volume = value;
    }
    public void KlickFSToggle()
    {
        Screen.fullScreen = fs_t.isOn;
    }

    public void resolutionLeft()
    {
        if (selectedResolution > 0) {
            selectedResolution--;
        }
        else
        {
            selectedResolution = 0;
        }
        SetResolution(Resolutions[selectedResolution].width, Resolutions[selectedResolution].height);
        updateResolutionText();
    }
    public void resolutionRight()
    {
        if (selectedResolution < Resolutions.Length - 2) 
        {
            selectedResolution++;
        }
        else
        {
            selectedResolution = (Resolutions.Length - 1);
        }
        SetResolution(Resolutions[selectedResolution].width, Resolutions[selectedResolution].height);
        updateResolutionText();
    }
    private void updateResolutionText()
    {
        ResolutionText.text = Resolutions[selectedResolution].width + "x" + Resolutions[selectedResolution].height;
    }
    public void SetResolution(int width, int height)
    {
        bool fs = Screen.fullScreen;
        var screenRefreshRate = 144;
        Screen.SetResolution(width, height, fs, screenRefreshRate);
    }
    void OnEnable()
    {
        s.value = PlayerLook.sensitivityScale;
        s_v.value = Player.volume;
        fs_t.isOn = Screen.fullScreen;
    }

}
