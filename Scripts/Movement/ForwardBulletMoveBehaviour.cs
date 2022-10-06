using UnityEngine;
public class ForwardBulletMoveBehaviour : EnemyMoveBehaviour
{
    [SerializeField]private float speed;
    public override float Speed => speed;
}