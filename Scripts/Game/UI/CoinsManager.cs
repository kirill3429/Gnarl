using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private GameScreen gameScreen;
    private int coins = 100;

    public int Coins { get => coins;}

    private void Start()
    {
        gameScreen.SetCoinsView(coins);
    }

    public void AddCoins(int c)
    {
        if (c > 0)
        {
            coins += c;
            gameScreen.SetCoinsView(coins);
        }
    }
    public void TakeCoins(int c)
    {
        if (c > 0)
        {
            coins -= c;
            gameScreen.SetCoinsView(coins);
        }
    }

}
