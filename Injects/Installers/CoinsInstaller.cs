using UnityEngine;
using Zenject;

public class CoinsInstaller : MonoInstaller
{
    [SerializeField] private CoinsPool coinsPool;
    public override void InstallBindings()
    {
        BindCoinsPool();
    }

    private void BindCoinsPool()
    {
        Container.Bind<CoinsPool>().FromInstance(coinsPool).AsSingle().NonLazy();
    }
}