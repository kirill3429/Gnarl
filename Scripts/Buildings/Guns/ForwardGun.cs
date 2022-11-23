using UnityEngine;
using UnityEngine.Pool;

public class ForwardGun : Build
{
    [SerializeField] private AbstractBullet bulletPrefab;
    [SerializeField] private Transform bulletSocket;
    private ObjectPool<AbstractBullet> bulletPool;
    private ObjectPool<GameObject> effectPool;

    private void Start()
    {
        bulletPool = new ObjectPool<AbstractBullet>(OnCreate, OnGet, OnRelease);
    }

    public override void Activate()
    {
        isActive = true;
    }

    public override void Deactivate()
    {
        isActive = false;
    }

    public override void Perform()
    {
        base.Perform();
        SpawnBullet();
    }

    private AbstractBullet OnCreate()
    {
        AbstractBullet bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletPool,effectPool);
        return bullet;
    }

    private void OnGet(AbstractBullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnRelease(AbstractBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void SpawnBullet()
    {
        var bullet = bulletPool.Get();
        bullet.transform.position = bulletSocket.position;
        bullet.transform.rotation = bulletSocket.rotation;
    }
}
