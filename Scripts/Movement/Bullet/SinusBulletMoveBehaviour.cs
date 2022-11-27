using UnityEngine;
public class SinusBulletMoveBehaviour : BulletMoveBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;
    public override float Speed => speed;

    public override void Move(float delta)
    {
        var f = Mathf.PingPong(Time.time * speed * speed, 8);
        Vector2 direction = (Vector2)myTransform.up;

        Translate(direction, delta);
    }

    private void Translate(Vector2 direction, float delta)
    {
        myTransform.position = (Vector2)myTransform.position + (direction.normalized * speed * delta);
    }
}