using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        UpdateHealthView();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UpdateHealthView();
    }

    public override void Heal(float heal)
    {
        base.Heal(heal);
        UpdateHealthView();
    }

    private void UpdateHealthView()
    {
        healthBar.fillAmount = HP / MaxHP;
        healthText.text = HP.ToString();
    }
    protected override void Die()
    {
        
    }
}
