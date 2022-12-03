using UnityEngine;

public class LaserGun : Build
{
    [SerializeField] private Laser laser;


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
        laser.gameObject.SetActive(true);
    }

}
