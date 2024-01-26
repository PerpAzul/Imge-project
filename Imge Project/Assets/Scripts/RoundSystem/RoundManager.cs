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

    [SerializeField] private TextMeshProUGUI zombiesRemainingUI;
    [SerializeField] private TextMeshProUGUI startRoundUI;


    void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        StartCoroutine(StartRound(5f));
        roundInProgress = false;
        zombiesRemainingUI.enabled = false;
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
        zombiesToSpawn = CalculateZombiesToSpawn(currentRound);
        zombiesRemaining = zombiesToSpawn;
        StartCoroutine(countdown(seconds));
        yield return new WaitForSeconds(seconds);
        SpawnZombies();
    }

    private IEnumerator countdown(float secondsLeft)
    {
        startRoundUI.text = "Round Starting In " + (secondsLeft).ToString("0");
        startRoundUI.enabled = true;
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            startRoundUI.text = "Round Starting In " + (secondsLeft).ToString("0");
        }
        startRoundUI.enabled = false;
        zombiesRemainingUI.enabled = true;
        zombiesRemainingUI.text = "Zombies Remaining: " + zombiesRemaining;
    }

    void EndRound()
    {
        roundInProgress = false;
        currentRound++;
        StartCoroutine(StartRound(15f));
    }

    int CalculateZombiesToSpawn(int round)
    {
        // An exponential growth: 10 * (round ^ 1.5)
        return Mathf.CeilToInt(10 * Mathf.Pow(round, 1.5f));
    }

    public void ZombieKilled()
    {
        zombiesRemaining--;
        zombiesRemainingUI.text = "Zombies remaining: " + zombiesRemaining;
    }

    private void SpawnZombies()
    {
        StartCoroutine(_enemySpawner.SpawnZombiesInSupermarket(zombiesToSpawn));
    }
}
