using UnityEngine;

public class DefaultBullet : Bullet
{

    private void Awake()
    {
        moveBehaviour = GetComponent<BulletMoveBehaviour>();
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        moveBehaviour.Move(delta);
        Health health = new Health();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            damageDealerBehaviour.DoDamage(damage, health);
        }
    }
}
