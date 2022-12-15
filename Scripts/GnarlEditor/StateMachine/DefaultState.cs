using UnityEngine;
using Zenject;

public class DefaultState : EditorState
{
    public DefaultState(EditorStateMachine stateMachine, DiContainer diContainer) : base(stateMachine, diContainer) { }

    public override void Tick(Ray ray)
    {
        
    }
    public override void CreateBuild(GameObject buildToSpawn, int cost)
    {
        if (stateMachine.coinsManager.Coins < cost)
            return;

        stateMachine.freeBuild = diContainer.InstantiatePrefab(buildToSpawn);
        stateMachine.freeBuildCost = cost;
        stateMachine.SetState(stateMachine.buildState);
    }
}