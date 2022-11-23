using UnityEngine;
using UnityEngine.Pool;
public abstract class AbstractBullet : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float lifeTime;
    [SerializeField] protected GameObject effectPrefab;
    protected ObjectPool<AbstractBullet> bulletPool;
    protected ObjectPool<GameObject> effectPool;
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
            bulletPool.Release(this);
        }
        moveBehaviour.Move(Time.deltaTime);
    }

    public void SetPool(ObjectPool<AbstractBullet> bulletPool, ObjectPool<GameObject> effectPool)
    {
        this.bulletPool = bulletPool;
        this.effectPool = effectPool;
    }
}