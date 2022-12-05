using UnityEngine;

public abstract class DamageDealerBehaviour : MonoBehaviour
{
    public void DoDamage(float damage, Health health, Rigidbody2D rb, float pushForce)
    {
        health.TakeDamage(damage);
        rb.AddForce(transform.up * pushForce, ForceMode2D.Impulse);
    }
    public void DoDamage(float damage, Health health)
    {
        health.TakeDamage(damage);
    }
}