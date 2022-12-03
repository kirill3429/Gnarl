using UnityEngine.Pool;
using UnityEngine;
using Zenject;

public class CoinsFactory : Build
{
    [SerializeField] private int coinsPerPeriod = 5;
    [SerializeField] private Color messageColor;
    [Inject] private CoinsManager coinsManager;

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

        coinsManager.AddCoins(coinsPerPeriod);

        var message = MessagesPool.pool.Get();
        message.transform.position = transform.position;
        message.ShowMessage("+ " + coinsPerPeriod.ToString(), messageColor);

    }
}
