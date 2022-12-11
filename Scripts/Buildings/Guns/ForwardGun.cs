

public class ForwardGun : Build
{
    private BulletsPool bulletsPool;

    private void Start()
    {
        bulletsPool = GetComponentInChildren<BulletsPool>();
    }

    public override void Activate()
    {
        isActive = true;
    }

    public override void Deactivate()
    {
        isActive = false;
    }

    public override void Initialize()
    {
        bulletsPool.InitializeGun();
    }

    public override void Perform()
    {
        base.Perform();
        bulletsPool.gameObject.SetActive(true);
    }

}
