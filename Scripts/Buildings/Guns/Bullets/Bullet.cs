using UnityEngine;
using UnityEngine.Pool;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float pushForce;
    [SerializeField] private float lifeTime;
    private float shotStartTime;

    private ObjectPool<Bullet> bulletPool;
    private EffectsPool effectPool;
    
    private BulletMoveBehaviour moveBehaviour;
    private DamageDealerBehaviour damageDealerBehaviour;


    private void Start()
    {
        moveBehaviour = GetComponent<BulletMoveBehaviour>();
        damageDealerBehaviour = GetComponent<DamageDealerBehaviour>();
    }

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

    public void SetPool(ObjectPool<Bullet> bulletPool, EffectsPool effectPool)
    {
        this.bulletPool = bulletPool;
        this.effectPool = effectPool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (gameObject.activeInHierarchy && collision.gameObject.TryGetComponent<Health>(out Health health))
            {
                damageDealerBehaviour.DoDamage(damage, health, collision.attachedRigidbody, pushForce);

                bulletPool.Release(this);
                var effect = effectPool.Get();
                effect.transform.position = transform.position;
            }
        }
        
    }
}