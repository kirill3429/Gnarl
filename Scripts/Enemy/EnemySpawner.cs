using UnityEngine;
using System.Collections;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private EnemyFactory enemyFactory;
    [SerializeField] private float spawnDispersion;
    [SerializeField] private float radius;
    [SerializeField] private float spawnSpeed;


    [SerializeField] private int maxEnemies;
    [SerializeField] private int enemiesPerWave;

    private int currentWave;

    [Inject] private Player player;

    private void Start()
    {
        enemyFactory = GetComponent<EnemyFactory>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (enemyFactory.CurrentCount < maxEnemies)
            {
                Vector3 spawnPoint = CreateSpawnPoint();
                enemyFactory.SpawnEnemy(spawnPoint);
            }

            if (enemyFactory.TotalSpawned % enemiesPerWave == 0)
            {
                currentWave++;
                enemyFactory.EnemyIDToSpawn++;
            }

            yield return new WaitForSeconds(1/spawnSpeed);
        }

    }

    private Vector3 CreateSpawnPoint()
    {
        Vector3 spawnPoint = new Vector3();
        float alpha = Random.Range(0, 360);
        float delta = Random.Range(0, spawnDispersion);
        spawnPoint.x = player.transform.position.x + ((radius + delta) * Mathf.Cos(alpha * Mathf.Deg2Rad));
        spawnPoint.y = player.transform.position.y + ((radius + delta) * Mathf.Sin(alpha * Mathf.Deg2Rad));
        return spawnPoint;
    }
}


