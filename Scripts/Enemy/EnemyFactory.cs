using UnityEngine.Pool;
using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    private ObjectPool<Health> enemyPool;

    //[SerializeField] private GameObject[] allEnemies;
    [SerializeField] private GameObject enemy;
    [Inject] DiContainer diContainer;
    private int currentEnemiesCount;
    private int enemyIDToSpawn;

    public int CurrentEnemiesCount { get => currentEnemiesCount;}

    private void Start()
    {
        enemyPool = new ObjectPool<Health>(OnCreateEnemy, OnGetEnemy, OnReleaseEnemy);
    }

    private Health OnCreateEnemy()
    {
        Health enemy = SpawnEnemy(enemyIDToSpawn);
        enemy.SetPool(enemyPool);
        return enemy;
    }
     
    private void OnGetEnemy(Health enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnReleaseEnemy(Health enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Health SpawnEnemy(int enemyId)
    {
        return diContainer.InstantiatePrefabForComponent<Health>(enemy);
    }
    public GameObject GetEnemy()
    {
        return enemyPool.Get().gameObject;
    }
}
