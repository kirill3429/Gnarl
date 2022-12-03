using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private AbstractBullet bulletPrefab;
    [SerializeField] private Transform bulletSocket;
    [SerializeField] private Effect effectPrefab;

    private ObjectPool<AbstractBullet> bulletPool;
    private GameObject bulletsContainer;

    private EffectsPool effectsPool;

    public void InitializeGun()
    {
        bulletsContainer = new GameObject(gameObject.name + "BulletsPool");
        bulletPool = new ObjectPool<AbstractBullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet);
        effectsPool = new EffectsPool(gameObject.name, effectPrefab);
    }

    #region bullet pool

    private AbstractBullet OnCreateBullet()
    {
        AbstractBullet bullet = Instantiate(bulletPrefab, bulletsContainer.transform, true);
        bullet.SetPool(bulletPool, effectsPool);
        return bullet;
    }

    private void OnGetBullet(AbstractBullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(AbstractBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    #endregion

    public void SpawnBullet()
    {
        var bullet = bulletPool.Get();
        bullet.transform.position = bulletSocket.position;
        bullet.transform.rotation = bulletSocket.rotation;
    }
}
