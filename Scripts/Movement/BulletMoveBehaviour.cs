using UnityEngine;
public abstract class BulletMoveBehaviour : MonoBehaviour
{
    public abstract float Speed { get;}
    protected Transform myTransform;

    protected void Awake()
    {
        myTransform = transform;
    }

    public virtual void Move(float delta)
    {
        myTransform.Translate(myTransform.up * Speed * delta);
    }
}