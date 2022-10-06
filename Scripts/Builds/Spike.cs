using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IBuild
{
    [SerializeField] private float damage;
    [SerializeField] private int weight;
    private Collider2D damageCollider;
    public int Weight { get => weight;}

    private void Awake()
    {
        damageCollider = GetComponent<Collider2D>();
    }

    public void Activate()
    {
        damageCollider.enabled = true;
    }

    public void Deactivate()
    {
        damageCollider.enabled = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionGameObject = collision.gameObject;

        if (collisionGameObject.TryGetComponent<Health>(out Health tempHealth))
        {
            tempHealth.TakeDamage(damage);
        }
        Vector2 pushDirection = collisionGameObject.transform.position - transform.position;
        collisionGameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection.normalized * 100, ForceMode2D.Impulse);
    }
}
