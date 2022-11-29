using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player player;
    public override void InstallBindings()
    {
        BindPlayer();
        BindPlayerInputHandler();
    }

    private void BindPlayer()
    {
        Container.Bind<Player>().FromInstance(player).AsSingle();
    }
    private void BindPlayerInputHandler()
    {
        Container.Bind<InputHandler>().FromInstance(player.GetComponent<InputHandler>()).AsSingle().NonLazy();
    }
}