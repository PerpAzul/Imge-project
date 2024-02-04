using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    private GameObject[] supermarketSpawnPoints;
    private GameObject[] citySpawnPoints;
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        supermarketSpawnPoints = GameObject.FindGameObjectsWithTag("SupermarketSpawnPoint");
        citySpawnPoints = GameObject.FindGameObjectsWithTag("CitySpawnPoint");
        Debug.Log("Length city spawn points: " + citySpawnPoints.Length);
        zombiePrefab.GetComponent<NavMeshAgent>().speed = 4;
    }

    public IEnumerator SpawnZombiesInSupermarket(int numberOfEnemies)
    {
        Debug.Log("Started spawning Zombies in Supermarket");
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
    
    public IEnumerator SpawnZombiesInCity(int numberOfEnemies)
    {
        Debug.Log("Started spawning Zombies in City");
        while (numberOfEnemies > 0)
        {
            numberOfEnemies -= 1;
            int spawnPointIndex = Random.Range(0, citySpawnPoints.Length);
            while (isSpawnPointInSight(citySpawnPoints[spawnPointIndex]))
            {
                Debug.Log("Zombie in sight");
                spawnPointIndex = Random.Range(0, citySpawnPoints.Length);
            }
            Instantiate(zombiePrefab, citySpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
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

    public void increaseZombieSpeed(float speedToIncrease)
    {
        zombiePrefab.GetComponent<NavMeshAgent>().speed += speedToIncrease;
    }
}