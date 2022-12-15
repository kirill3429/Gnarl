using UnityEngine;
using Zenject;

public class GnarlEditorInstaller : MonoInstaller
{
    [SerializeField] private EditorStateMachine stateMachine;
    [SerializeField] private CoinsManager coinsManager;
    [SerializeField] private EditorSideBlock editorSideBlock;
    public override void InstallBindings()
    {
        BindStateMachine();
        BindCoinsManager();
        BindSideBlock();
    }

    private void BindSideBlock()
    {
        Container.Bind<EditorSideBlock>().FromInstance(editorSideBlock).AsSingle().NonLazy();
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