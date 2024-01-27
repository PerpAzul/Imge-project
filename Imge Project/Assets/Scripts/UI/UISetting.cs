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
    // Update is called once per frame
    void Update()
    {
        SensitivityText.text = PlayerLook.sensitivityScale.ToString("0.##");
        VolumeText.text = Player.volume.ToString("0.##");
    }
    public void changeSensitivity(float value)
    {
        PlayerLook.sensitivityScale = value;
        s.value = PlayerLook.sensitivityScale;
    }
    public void changeVolume(float value)
    {
        Player.volume = value;
        s_v.value = Player.volume;
    }
}
