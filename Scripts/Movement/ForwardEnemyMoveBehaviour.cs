using UnityEngine;
public class ForwardEnemyMoveBehaviour : EnemyMoveBehaviour
{
    [SerializeField]private float speed;
    public override float Speed => speed;
}