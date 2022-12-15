using UnityEngine;
using Zenject;
public abstract class EditorState
{
    protected DiContainer diContainer;
    public EditorStateMachine stateMachine;
    public EditorState(EditorStateMachine stateMachine, DiContainer diContainer)
    {
        this.stateMachine = stateMachine;
        this.diContainer = diContainer;
    }
    
    public abstract void Tick(Ray ray);
    public abstract void CreateBuild(GameObject buildToSpawn, int cost);
}




