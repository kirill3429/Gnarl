 
using UnityEngine;

public class RotateBooster : Build
{
    [SerializeField] private float rotateBoost;
    
    public override void Activate()
    {
        isActive = false;
    }

    public override void Deactivate()
    {
        isActive = false;
    }

    public override void Perform()
    {
    }

    public override void Initialize()
    {
        PlayerLocomotion playerLocomotion = GetComponentInParent<PlayerLocomotion>();
        playerLocomotion.RotationSpeed += rotateBoost;
    }
}
