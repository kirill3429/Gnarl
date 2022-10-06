using UnityEngine;
public abstract class EnemyMoveBehaviour : MonoBehaviour
{
    public abstract float Speed { get;}
    protected Rigidbody2D rb;
    private Transform myTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myTransform = transform;
    }

    public virtual void Move(float delta)
    {
        rb.AddForce(myTransform.up * Speed * delta, ForceMode2D.Impulse);
    }
}