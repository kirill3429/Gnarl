using UnityEngine;
using Zenject;

public class GnarlEditorInstaller : MonoInstaller
{
    [SerializeField] private EditorStateMachine stateMachine;
    [SerializeField] private CoinsManager coinsManager;
    public override void InstallBindings()
    {
        BindStateMachine();
        BindCoinsManager();
    }

    private void BindStateMachine()
    {
        Container.Bind<EditorStateMachine>().FromInstance(stateMachine).AsSingle().NonLazy();
    }
    private void BindCoinsManager()
    {
        Container.Bind<CoinsManager>().FromInstance(coinsManager).AsSingle().NonLazy();
    }
}