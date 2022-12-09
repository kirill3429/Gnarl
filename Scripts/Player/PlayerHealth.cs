using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private DeathScreen deathScreen;

    private void Start()
    {
        gameScreen.SetHealthView(HP, MaxHP);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        gameScreen.SetHealthView(HP, MaxHP);
    }

    public override void Heal(float heal)
    {
        base.Heal(heal);
        gameScreen.SetHealthView(HP, MaxHP);
    }

    protected override void Die()
    {
        deathScreen.Show();

    }
}
