using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Build
{
    [SerializeField] private float damage;
    [SerializeField] private float pushForce;

    private Animator animator;
    private DamageDealerBehaviour damageDealerBehaviour;
    private Collider2D damageCollider;

    private void Awake()
    {
        damageDealerBehaviour = GetComponent<DamageDealerBehaviour>();
        damageCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        Activate();
    }

    public override void Activate()
    {
        damageCollider.enabled = true;
    }

    public override void Deactivate()
    {
        damageCollider.enabled = false;
    }



    public override void Perform()
    {
        base.Perform();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionGameObject = collision.gameObject;

        if (collisionGameObject.TryGetComponent<Health>(out Health tempHealth))
        {
            damageDealerBehaviour.DoDamage(damage, tempHealth); 
            Push(collisionGameObject);
        }
    }

    private void Push(GameObject collisionGameObject)
    {
        Vector2 pushDirection = collisionGameObject.transform.position - transform.position;
        collisionGameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection.normalized * pushForce, ForceMode2D.Impulse);
    }
}
