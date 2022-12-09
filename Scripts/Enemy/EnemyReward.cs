using UnityEngine;
using Zenject;

public class EnemyReward : MonoBehaviour
{
    [Inject] private CoinsPool coinsPool;

    public void SpawnCoin()
    {
        Coin coin = coinsPool.GetCoin();
        coin.transform.position = transform.position;
    }
}
