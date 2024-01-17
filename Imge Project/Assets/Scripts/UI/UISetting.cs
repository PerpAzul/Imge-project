using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    //sensitivity UI Text
    public TextMeshProUGUI SensitivityText;

    public Slider s;
    // Update is called once per frame
    void Update()
    {
        SensitivityText.text = s.value.ToString();
    }
}
