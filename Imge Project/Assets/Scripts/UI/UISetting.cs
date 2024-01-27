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
    }
    void OnEnable()
    {
        s.value = PlayerLook.sensitivityScale;
        s_v.value = Player.volume;
    }

}
