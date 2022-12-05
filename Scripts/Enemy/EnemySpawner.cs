using UnityEngine;
using System.Collections;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private EnemyFactory enemyFactory;
    private float spawnDispersion;
    private float radius;
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
            if (enemyFactory.CurrentEnemiesCount < 50)
            {
                enemyFactory.GetEnemy();
            }

            yield return new WaitForSeconds(0.5f);
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


