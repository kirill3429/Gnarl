using UnityEngine;

public class DefaultBullet : AbstractBullet
{
    [SerializeField] private float pushForce;
    private void Start()
    {
        moveBehaviour = GetComponent<BulletMoveBehaviour>();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy && collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            damageDealerBehaviour.DoDamage(damage, health, collision.attachedRigidbody, pushForce);

            bulletPool.Release(this);
            var effect = effectPool.Get();
            effect.transform.position = transform.position;
        }
    }
}