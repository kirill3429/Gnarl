using UnityEngine;
public abstract class AbstractBullet : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float lifeTime;
    protected float shotStartTime;
    public BulletMoveBehaviour moveBehaviour;
    public DamageDealerBehaviour damageDealerBehaviour;

    protected void OnEnable()
    {
        shotStartTime = Time.time;
    }

    protected virtual void Update()
    {
        if (Time.time - shotStartTime > lifeTime)
        {
            // return to Pool;
        }
        moveBehaviour.Move(Time.deltaTime);
    }

}