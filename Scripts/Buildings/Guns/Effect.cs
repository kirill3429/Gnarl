using UnityEngine;
using UnityEngine.Pool;

public class Effect : MonoBehaviour
{
    private ObjectPool<Effect> effectPool;

    public void SetPool(ObjectPool<Effect> effectPool)
    {
        this.effectPool = effectPool;
    }

    public void OnParticleSystemStopped()
    {
        effectPool.Release(this);
    }
}
