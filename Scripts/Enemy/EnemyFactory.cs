using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] allEnemies;
    [SerializeField] private Transform enemyContainer;
    [Inject] DiContainer diContainer;
    private int totalSpawned = 1;
    private int enemyIDToSpawn = 0;
    public int TotalSpawned { get => totalSpawned; }
    public int EnemyIDToSpawn
    {
        get => enemyIDToSpawn; 
        set
        {
            if (enemyIDToSpawn < allEnemies.Length) 
            {
                enemyIDToSpawn = value;
            }
        }
    }
    public int CurrentCount { get => enemyContainer.childCount; }

    public GameObject SpawnEnemy(Vector3 spawnPoint)
    {
        totalSpawned++;
        var enemy = diContainer.InstantiatePrefab(allEnemies[enemyIDToSpawn], enemyContainer);
        enemy.transform.position = spawnPoint;
        return enemy;
    }
}
