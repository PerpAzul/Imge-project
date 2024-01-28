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

    public Slider s;
    public Slider s_v;
    public Toggle fs_t;
    // Update is called once per frame
    private void Awake()
    {
        fs_t.isOn = Screen.fullScreen;
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

    void OnEnable()
    {
        s.value = PlayerLook.sensitivityScale;
        s_v.value = Player.volume;
        fs_t.isOn = Screen.fullScreen;
    }

}
