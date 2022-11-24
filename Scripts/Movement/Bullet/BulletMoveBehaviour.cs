using UnityEngine;
public abstract class BulletMoveBehaviour : MonoBehaviour
{
    public abstract float Speed { get;}
    protected Transform myTransform;

    protected void Start()
    {
        myTransform = transform;
    }

    public virtual void Move(float delta)
    {
        Vector2 direction = new Vector2(0,1);
        myTransform.Translate(direction * Speed * delta);
    }
}