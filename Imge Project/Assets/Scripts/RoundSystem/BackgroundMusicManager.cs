using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static float volume = 1f;
    
    public static void changeVolume(float value)
    {
        volume = value;
    }

    private void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = volume;
    }
}
