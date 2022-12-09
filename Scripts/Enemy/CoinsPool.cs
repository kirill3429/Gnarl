using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class CoinsPool : MonoBehaviour
{
    private ObjectPool<Coin> coinsPool;
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private Transform coinsContainer;

    [Inject] DiContainer diContainer;

    private void Start()
    {
        coinsPool = new ObjectPool<Coin>(OnCreateCoin, OnGetCoin, OnReleaseCoin);
    }

    private Coin OnCreateCoin()
    {
        Coin coin = diContainer.InstantiatePrefabForComponent<Coin>(coinPrefab, coinsContainer);
        coin.SetPool(coinsPool);
        return coin;
    }

    private void OnGetCoin(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    private void OnReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    public Coin GetCoin()
    {
        return coinsPool.Get();
    }
    public void Release(Coin coin)
    {
        coinsPool.Release(coin);
    }
}
