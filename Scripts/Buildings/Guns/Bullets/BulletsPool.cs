using UnityEngine;
using UnityEngine.Pool;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletSocket;
    [SerializeField] private Effect effectPrefab;

    [SerializeField] private float cooldown;
    [SerializeField] private int count = 3;
    private int performedCount = 0;

    private float lastShotTime;

    private ObjectPool<Bullet> bulletPool;
    private GameObject bulletsContainer;

    private EffectsPool effectsPool;

    private void OnEnable()
    {
        lastShotTime = Time.time;
    }

    public void InitializeGun()
    {
        bulletsContainer = new GameObject(gameObject.name + "BulletsPool");
        bulletPool = new ObjectPool<Bullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet);
        effectsPool = new EffectsPool(gameObject.name, effectPrefab);
    }
    private void FixedUpdate()
    {
        if (Time.time - lastShotTime > cooldown)
        {
            SpawnBullet();
            lastShotTime = Time.time;
            performedCount++;
        }
        if (performedCount >= count)
        {
            performedCount = 0;
            gameObject.SetActive(false);
        }
    }


    #region bullet pool

    private Bullet OnCreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletsContainer.transform, true);
        bullet.SetPool(bulletPool, effectsPool);
        return bullet;
    }

    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    #endregion

    private void SpawnBullet()
    {
        var bullet = bulletPool.Get();
        bullet.transform.position = bulletSocket.position;
        bullet.transform.rotation = bulletSocket.rotation;
    }
}
