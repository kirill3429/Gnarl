using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager singleton;
    [SerializeField] private TextMeshProUGUI coinsText;
    private int coins = 100;
    public int Coins { get => coins;}

    private void Start()
    {
        singleton = this;
        UpdateCoinsText();
    }

    public void AddCoins(int c)
    {
        if (c > 0)
        {
            coins += c;
            UpdateCoinsText();
        }
    }
    public void TakeCoins(int c)
    {
        if (c > 0)
        {
            coins -= c;
            UpdateCoinsText();
        }
    }
    private void UpdateCoinsText()
    {
        coinsText.text = coins.ToString();
    }
}
