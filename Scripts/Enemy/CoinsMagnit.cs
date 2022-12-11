using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CoinsMagnit : MonoBehaviour
{
    private Coin[] activeCoins;
    [Inject] private Player player;
    [SerializeField] private float coinSpeed;
    List<Coin> coins;
    public void GetAllCoins()
    {
        activeCoins = GetComponentsInChildren<Coin>(false);

        coins = activeCoins.ToList();

        StartCoroutine(MoveCoinsTowardsPlayer());
    }

    private IEnumerator MoveCoinsTowardsPlayer()
    {
        while (coins.Count > 0)
        {
            foreach (Coin i in coins)
            {
                Vector3 direction = player.transform.position - i.transform.position;
                i.transform.position = i.transform.position + direction.normalized * coinSpeed * Time.deltaTime;
            }
            coins.RemoveAll(coin => coin.gameObject.activeSelf == false);
            yield return null;
        }
        Debug.Log("Dobe");
    }
}
