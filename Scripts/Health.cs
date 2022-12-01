using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] private float maxHealthPoints;

    public float HP { get => healthPoints; }
    public float MaxHP { get => maxHealthPoints; }

    public virtual void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;
        else
            healthPoints -= damage;

        if (healthPoints <= 0)
            Die();
    }

    public virtual void Heal(float heal)
    {
        if (heal > 0)
            if (healthPoints + heal > maxHealthPoints)
                healthPoints = maxHealthPoints;
            else
                healthPoints += heal;
    }


    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
