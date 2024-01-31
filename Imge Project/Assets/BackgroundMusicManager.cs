using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static float volume = 0.21f;
    
    public static void changeVolume(float value)
    {
        Debug.Log(value);
        volume = 0.2f * value;
    }

    private void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = volume;
    }
}
