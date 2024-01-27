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
    //private PlayerLook _playerLook;

    public Slider s;
    public Slider s_v;
    // Update is called once per frame
    void Awake()
    {
        //_playerLook = new PlayerLook();
    }
    void Update()
    {
        SensitivityText.text = s.value.ToString("0.##");
        VolumeText.text = s_v.value.ToString("0.##");
    }
    public void changeSensitivity(float value)
    {
        PlayerLook.sensitivityScale = value;
        //PlayerLook.changeSensitivity(s.value);
    }
    public void changeVolume(float value)
    {
        Player.volume = value;
    }
}
