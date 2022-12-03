using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EffectsPool
{
    private Effect effectPrefab;
    private string ownerName;

    private ObjectPool<Effect> effectPool;
    private GameObject effectsContainer;

    public EffectsPool(string ownerName, Effect effectPrefab)
    {
        this.ownerName = ownerName;
        this.effectPrefab = effectPrefab;
        InitializePool();
    }

    public void InitializePool()
    {
        effectPool = new ObjectPool<Effect>(OnCreateEffect, OnGetEffect, OnReleaseEffect);
        effectsContainer = new GameObject(ownerName + "EffectsPool");
    }
    private Effect OnCreateEffect()
    {
        Effect effect = GameObject.Instantiate(effectPrefab, effectsContainer.transform);
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

    public Effect Get()
    {
        return effectPool.Get();
    }
    public void Release(Effect effect)
    {
        effectPool.Release(effect);
    }

    public void DestroyPool()
    {
        GameObject.Destroy(effectsContainer);
        effectPool.Dispose();
    }
}
