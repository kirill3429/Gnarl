using System;
using UnityEngine;

public class SphereShield : Health
{
    [SerializeField] private SpriteRenderer shieldSprite;
    private Collider2D shieldCollider;
    

    private void Start()
    {
        shieldCollider = GetComponent<Collider2D>();
    }

    public void AddEnergy(float energyPerCooldown)
    {
        Heal(energyPerCooldown);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UpdateShield();
    }

    private void UpdateShield()
    {
        shieldSprite.color = new Color(shieldSprite.color.r, shieldSprite.color.g, shieldSprite.color.b, HP / MaxHP/2);
    }

    public override void Heal(float heal)
    {
        base.Heal(heal);
        if (HP > 0)
        {
            shieldCollider.enabled = true;
        }
        UpdateShield();
        
    }

    public override void Die()
    {
        shieldCollider.enabled = false;
    }
}