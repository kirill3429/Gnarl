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
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            damageDealerBehaviour.DoDamage(damage, health);
        }
    }
}
