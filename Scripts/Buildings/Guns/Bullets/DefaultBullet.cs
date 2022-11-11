using UnityEngine;

public class DefaultBullet : AbstractBullet
{

    private void Awake()
    {
        moveBehaviour = GetComponent<BulletMoveBehaviour>();
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        moveBehaviour.Move(delta);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            damageDealerBehaviour.DoDamage(damage, health);
        }
    }
}
