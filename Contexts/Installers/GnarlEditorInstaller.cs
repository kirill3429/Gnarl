using UnityEngine;
using Zenject;

public class GnarlEditorInstaller : MonoInstaller
{
    [SerializeField] private EditorStateMachine stateMachine;
    public override void InstallBindings()
    {
        BindStateMachine();
    }

    private void BindStateMachine()
    {
        Container.Bind<EditorStateMachine>().FromInstance(stateMachine).AsSingle().NonLazy();
    }
}