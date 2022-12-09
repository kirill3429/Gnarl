using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    [Inject] private CoinsManager coinsManager;
    private ObjectPool<Coin> coinsPool;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinsManager.AddCoins(value);
        coinsPool.Release(this);
    }

    public void SetPool(ObjectPool<Coin> coinsPool)
    {
        this.coinsPool = coinsPool;
    }
}
