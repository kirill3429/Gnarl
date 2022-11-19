using UnityEngine;
public abstract class EditorState
{
    public EditorStateMachine stateMachine;
    public EditorState(EditorStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    public abstract void Tick(Ray ray);
    public abstract void CreateBuild(GameObject buildToSpawn, int cost);
}




