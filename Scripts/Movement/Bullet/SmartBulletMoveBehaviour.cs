using UnityEngine;
public class SmartBulletMoveBehaviour : BulletMoveBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float searchRadius;
    [SerializeField] private float smooth;
    [SerializeField] private LayerMask enemyLayer;
    private Transform target;
    private Collider2D[] targetCollider = new Collider2D[1];
    public override float Speed => speed;

    public override void Move(float delta)
    {
        if (target == null)
        {
            Physics2D.OverlapCircleNonAlloc(myTransform.position, searchRadius, targetCollider, enemyLayer);
            if (targetCollider[0] != null)
            {
                target = targetCollider[0].transform;
            }
            else
            {
                Translate(myTransform.up, delta);
            }
        }
        else
        {
            Vector2 direction = target.position - myTransform.position;
            direction = Vector2.Lerp(myTransform.forward, direction, smooth);

            Translate(direction, delta);
        }

        
    }
    private void Translate(Vector2 direction, float delta)
    {
        myTransform.Translate(direction.normalized * speed * delta);
    }
}