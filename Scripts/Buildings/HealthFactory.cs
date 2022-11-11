using UnityEngine.Pool;
using UnityEngine;

public class HealthFactory : Build
{
    [SerializeField] private int healthPerPeriod = 5;
    [SerializeField] private Color messageColor;
    private PlayerHealth health;

    public override void Activate()
    {
        if (health == null)
        {
            health = GetComponentInParent<PlayerHealth>();
        }
        isActive = true;
    }

    public override void Deactivate()
    {
        isActive = false;
    }

    public override void Perform()
    {
        base.Perform();
        health.Heal(healthPerPeriod);

        var message = MessagesPool.pool.Get();
        message.transform.position = transform.position;
        message.ShowMessage("+ " + healthPerPeriod.ToString(), messageColor);

    }
}
