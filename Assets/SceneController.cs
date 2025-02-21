using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int currentWave = 1;
    private int enemiesToSpawn;
    private float spawnDelay = 3f;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private bool isSpawningWave;

    void Start()
    {
        SpawnEnemiesForWave(currentWave);
    }

    void Update()
    {
        if (spawnedEnemies.Count == 0 && !isSpawningWave)
        {
            currentWave++;
            if (currentWave <= 3)
            {
                StartCoroutine(SpawnNextWave());
            }
            else
            {
                Debug.Log("Player Wins!");
            }
        }
    }

    void SpawnEnemiesForWave(int wave)
    {
        enemiesToSpawn = wave;
        spawnedEnemies.Clear();

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.SetHealth(wave);
            }
            spawnedEnemies.Add(enemy);
        }
    }

    IEnumerator SpawnNextWave()
    {
        isSpawningWave = true;
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemiesForWave(currentWave);
        isSpawningWave = false;
    }

    public void EnemyDied(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
    }
}
