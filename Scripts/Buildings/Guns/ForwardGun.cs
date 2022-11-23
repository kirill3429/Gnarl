using UnityEngine;
using UnityEngine.Pool;

public class ForwardGun : Build
{
    private BulletsPool bulletsPool;

    private void Start()
    {
        bulletsPool = GetComponent<BulletsPool>();
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
        bulletsPool.SpawnBullet();
    }

}
