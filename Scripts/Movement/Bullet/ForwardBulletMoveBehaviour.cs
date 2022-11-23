using UnityEngine;
public class ForwardBulletMoveBehaviour : BulletMoveBehaviour
{
    [SerializeField]private float speed;
    public override float Speed => speed;
}