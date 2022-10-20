using UnityEngine;
public class SinusBulletMoveBehaviour : BulletMoveBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;
    public override float Speed => speed;

    public override void Move(float delta)
    {
        var f = Mathf.PingPong(Time.time * speed * speed, 8);
        Vector2 direction = new Vector2((f - 8), 1 * speed);

        myTransform.Translate(direction * delta);
    }
}