using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    private int coins = 100;
    public int Coins { get => coins;}

    private void Start()
    {
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
