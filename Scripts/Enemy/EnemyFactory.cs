
using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] allEnemies;
    [Inject] DiContainer diContainer;

    public void SpawnEnemy(int enemyId)
    {
        
    }
}
