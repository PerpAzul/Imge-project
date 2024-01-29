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
    public static float volume = 1.0f;
    [SerializeField] private TextMeshProUGUI healthUI;
    [SerializeField] private GameObject endUI;
    
    [SerializeField] private Player player;
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private TextMeshProUGUI escape;
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI roundCount;
    
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
        damagedMusic.volume = volume;
        damagedMusic.Play();
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            endUI.SetActive(true);
            escape.text = "YOU DIED!";
            roundCount.text = "You Died in Round: " + roundManager.currentRound;
            killCount.text = "Zombies Killed: " + player.killCount;
        }
    }
}