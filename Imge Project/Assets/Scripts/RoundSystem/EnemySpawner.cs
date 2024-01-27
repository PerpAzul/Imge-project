using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    private GameObject[] supermarketSpawnPoints;
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        supermarketSpawnPoints = GameObject.FindGameObjectsWithTag("SupermarketSpawnPoint");
    }

    public IEnumerator SpawnZombiesInSupermarket(int numberOfEnemies)
    {
        Debug.Log("Started spawning Zombies");
        while (numberOfEnemies > 0)
        {
            numberOfEnemies -= 1;
            int spawnPointIndex = Random.Range(0, supermarketSpawnPoints.Length);
            while (isSpawnPointInSight(supermarketSpawnPoints[spawnPointIndex]))
            {
                Debug.Log("Zombie in sight");
                spawnPointIndex = Random.Range(0, supermarketSpawnPoints.Length);
            }
            Instantiate(zombiePrefab, supermarketSpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            Debug.Log("Zombie Spawned");
            yield return new WaitForSeconds(3);
        }
    }

    private bool isSpawnPointInSight(GameObject spawnPoint)
    {
        Vector3 directionToPlayer = playerTransform.position - spawnPoint.transform.position;
        float distanceToPlayer = Vector3.Distance(spawnPoint.transform.position, playerTransform.position);
        Ray ray = new Ray(spawnPoint.transform.position, directionToPlayer);
        if (Physics.Raycast(ray, out RaycastHit hit, distanceToPlayer + 1f))
        {
            return hit.collider.gameObject.CompareTag("Player");
        }
        return false;
    }

    public void increaseZombieHealth(int healthToIncrease)
    {
        zombiePrefab.GetComponent<Enemy>().health += healthToIncrease;
    } 
}