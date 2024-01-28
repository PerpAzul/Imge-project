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
    [SerializeField] 
    private Toggle fullScreenToggle;
    public static bool gamingOptionIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenToggle.isOn = Screen.fullScreen;
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
        int temp = (int)(30.0f * PlayerLook.sensitivityScale);
        SensitivityText.text = temp.ToString();
        VolumeText.text = (100 * Player.volume).ToString("###");
        if (Input.GetKeyDown(KeyCode.Escape) && gamingOptionIsOpen)
        {
            CloseOptions();
        }
    }
    public void changeS(float value)
    {
        PlayerLook.sensitivityScale = value;
    }
    public void changeV(float value)
    {
        Player.volume = value;
        PlayerHealth.volume = value;
        Shooting.volume = value;
        Enemy.volume = value;
        PlayerInteract.volume = value;
    }
    public void KlickFSToggle()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
    }

    void OnEnable()
    {
        sensitivitySlider.value = PlayerLook.sensitivityScale;
        volumeSlider.value = Player.volume;
        fullScreenToggle.isOn = Screen.fullScreen;
    }

}
