using UnityEngine;

public abstract class DamageDealerBehaviour : MonoBehaviour
{
    public void DoDamage(float damage, Health health)
    {
        health.TakeDamage(damage);
    }
}