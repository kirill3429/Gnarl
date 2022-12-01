using UnityEngine;

public class DefaultBullet : AbstractBullet
{
    private void Start()
    {
        moveBehaviour = GetComponent<BulletMoveBehaviour>();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.activeInHierarchy && collision.collider.gameObject.TryGetComponent<Health>(out Health health))
        {
            damageDealerBehaviour.DoDamage(damage, health);
            bulletPool.Release(this);

            var effect = effectPool.Get();
            effect.transform.position = transform.position;
        }
    }
}
