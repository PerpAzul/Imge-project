using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int currentRound = 1;
    private int zombiesToSpawn;
    private int zombiesRemaining;
    private bool roundInProgress;
    private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerHealth health;

    [SerializeField] private TextMeshProUGUI roundUI;
    [SerializeField] private TextMeshProUGUI startRoundUI;


    public void StartGame()
    {
        StartCoroutine(StartRound(5f));
    }
    
    void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        roundInProgress = false;
        roundUI.enabled = false;
        startRoundUI.enabled = false;
    }

    void Update()
    {
        if (roundInProgress && zombiesRemaining <= 0)
        {
            EndRound();
        }
    }

    private IEnumerator StartRound(float seconds)
    {
        roundInProgress = true;
        startRoundUI.enabled = true;
        zombiesToSpawn = CalculateZombiesToSpawn(currentRound);
        zombiesRemaining = zombiesToSpawn;
        StartCoroutine(countdown(seconds));
        yield return new WaitForSeconds(seconds);
        SpawnZombies();
    }

    private IEnumerator countdown(float secondsLeft)
    {
        startRoundUI.text = "Round " + currentRound +" Starting In " + (secondsLeft).ToString("0");
        startRoundUI.enabled = true;
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            startRoundUI.text = "Round " + currentRound +" Starting In " + (secondsLeft).ToString("0");
        }
        startRoundUI.enabled = false;
        roundUI.enabled = true;
        roundUI.text = "Round: " + currentRound;
    }

    void EndRound()
    {
        roundInProgress = false;
        currentRound++;
        health.currentHealth = health.maxHealth;
        _enemySpawner.increaseZombieHealth(5);
        StartCoroutine(StartRound(15f));
    }

    int CalculateZombiesToSpawn(int round)
    {
        // An exponential growth: 2 * (round ^ 1.5)
        if (round > 10) return 64;
        return Mathf.CeilToInt(2 * Mathf.Pow(round, 1.5f));
    }

    public void ZombieKilled()
    {
        zombiesRemaining--;
    }

    private void SpawnZombies()
    {
        StartCoroutine(_enemySpawner.SpawnZombiesInSupermarket(zombiesToSpawn));
    }
}
