 
using UnityEngine;

public class Shield : Build
{
    [SerializeField] private SphereShield sphereShield;
    [SerializeField] private float energyPerCooldown;
    public override void Activate()
    {
        sphereShield.gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        sphereShield.gameObject.SetActive(false);
    }

    public override void Perform()
    {
        base.Perform();
        sphereShield.AddEnergy(energyPerCooldown);

    }
}
