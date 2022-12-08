 
using UnityEngine;

public class SpeedBooster : Build
{
    [SerializeField] private float moveBoost;
    
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
        playerLocomotion.MovementSpeed += moveBoost;
    }
}
