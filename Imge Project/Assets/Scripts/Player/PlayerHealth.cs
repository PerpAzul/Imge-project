using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxHealth = 5;

    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;
    private AudioSource damagedMusic;
    [SerializeField] private TextMeshProUGUI healthUI;
    
    void Start()
    {
        currentHealth = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        AudioSource[] audioSources = GetComponents<AudioSource>();
        damagedMusic = audioSources[3];
    }
    
    void Update()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }

        healthUI.text = "Health: " + currentHealth;
    }

    public void TakeDamage()
    {
        currentHealth--;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1f);
        damagedMusic.Play();
    }
}