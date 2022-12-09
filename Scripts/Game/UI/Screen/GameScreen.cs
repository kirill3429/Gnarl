using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameScreen : Screen
{
    [SerializeField] private TextMeshProUGUI coinsText;

    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    public void SetCoinsView(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void SetHealthView(float HP, float MaxHP)
    {
        healthBar.fillAmount = HP / MaxHP;
        healthText.text = HP.ToString();
    }
}
