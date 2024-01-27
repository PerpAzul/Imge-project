using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GamingOptions : MonoBehaviour
{
    [SerializeField]
    private  GameObject Options;
    [SerializeField]
    private TextMeshProUGUI SensitivityText;
    [SerializeField]
    private TextMeshProUGUI VolumeText;
    [SerializeField]
    private Slider sensitivitySlider;
    [SerializeField]
    private Slider volumeSlider;

    public static bool gamingOptionIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Options.SetActive(false);
    }
    public void LoadOptions()
    {
        Options.SetActive(true);
        gamingOptionIsOpen = true;
    }
    public void CloseOptions()
    {
        Options.SetActive(false);
        gamingOptionIsOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        SensitivityText.text = PlayerLook.sensitivityScale.ToString("0.##");
        VolumeText.text = Player.volume.ToString("0.##");
        if (Input.GetKeyDown(KeyCode.Escape) && gamingOptionIsOpen)
        {
            CloseOptions();
        }
    }
    public void changeS(float value)
    {
        PlayerLook.sensitivityScale = value;
        sensitivitySlider.value = PlayerLook.sensitivityScale;
    }
    public void changeV(float value)
    {
        Player.volume = value;
        volumeSlider.value = Player.volume;
    }
}
