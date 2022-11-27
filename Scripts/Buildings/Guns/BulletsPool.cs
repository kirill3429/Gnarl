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
    private ObjectPool<Effect> effectPool;
    private GameObject bulletsContainer;
    private GameObject effectsContainer;

    private bool isInited = false;

    public void InitializeGun()
    {
        bulletsContainer = new GameObject(gameObject.name + "BulletsPool");
        effectsContainer = new GameObject(gameObject.name + "EffectsPool");
        bulletPool = new ObjectPool<AbstractBullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet);
        effectPool = new ObjectPool<Effect>(OnCreateEffect, OnGetEffect, OnReleaseEffect);
    }

    #region bullet pool

    private AbstractBullet OnCreateBullet()
    {
        AbstractBullet bullet = Instantiate(bulletPrefab, bulletsContainer.transform, true);
        bullet.SetPool(bulletPool, effectPool);
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

    #region effect pool
    private Effect OnCreateEffect()
    {
        Effect effect = Instantiate(effectPrefab, effectsContainer.transform);
        effect.SetPool(effectPool);
        return effect;
    }

    private void OnGetEffect(Effect effect)
    {
        effect.gameObject.SetActive(true);
    }

    private void OnReleaseEffect(Effect effect)
    {
        effect.gameObject.SetActive(false);
    }
    #endregion

    public void SpawnBullet()
    {
        if (!isInited)
        {
            InitializeGun();
            isInited = true;
        }
        var bullet = bulletPool.Get();
        bullet.transform.position = bulletSocket.position;
        bullet.transform.rotation = bulletSocket.rotation;
    }
}
