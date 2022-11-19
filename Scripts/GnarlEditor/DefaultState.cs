using UnityEngine;
public class DefaultState : EditorState
{
    public DefaultState(EditorStateMachine stateMachine) : base(stateMachine) { }

    public override void Tick(Ray ray)
    {

    }
    public override void CreateBuild(GameObject buildToSpawn, int cost)
    {
        if (CoinsManager.singleton.Coins < cost)
            return;

        stateMachine.freeBuild = GameObject.Instantiate(buildToSpawn);
        stateMachine.freeBuildCost = cost;
        stateMachine.SetState(stateMachine.buildState);
    }
}