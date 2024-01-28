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
    public TextMeshProUGUI ResolutionText;
    [SerializeField]
    private Slider sensitivitySlider;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField] 
    private Toggle fullScreenToggle;
    public static bool gamingOptionIsOpen = false;
    
    private struct res {
        public int width;
        public int height;
    }
    private res[] Resolutions = new res[5];
    private int selectedResolution = 1;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenToggle.isOn = Screen.fullScreen;
        Options.SetActive(false);
        Resolutions[0].width    = 1280;
        Resolutions[0].height   =  720;
        Resolutions[1].width    = 1920;
        Resolutions[1].height   = 1080;
        Resolutions[2].width    = 2560;
        Resolutions[2].height   = 1440;
        Resolutions[3].width    = 3840;
        Resolutions[3].height   = 2160;
        Resolutions[4].width    = 4096;
        Resolutions[4].height   = 2160;
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
        sensitivitySlider.value = PlayerLook.sensitivityScale;
        volumeSlider.value = Player.volume;
        fullScreenToggle.isOn = Screen.fullScreen;
    }

}
