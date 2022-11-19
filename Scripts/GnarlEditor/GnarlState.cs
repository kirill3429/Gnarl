using UnityEngine;

public class GnarlState : EditorState
{
    public GnarlState(EditorStateMachine stateMachine) : base(stateMachine) { }
    public override void Tick(Ray ray)
    {
        FollowMouse(ray);
        if (stateMachine.InputHandler.mouseRightClick)
        {
            Cancel();
        }

    }
    public override void CreateBuild(GameObject buildToSpawn, int cost)
    {
        Cancel();
        stateMachine.freeBuild = GameObject.Instantiate(buildToSpawn);
        stateMachine.SetState(stateMachine.buildState);
    }

    private void FollowMouse(Ray ray)
    {
        Plane ground = new Plane(-Vector3.forward, Vector3.zero);

        if (ground.Raycast(ray, out float position))
        {
            Vector2 mouseWorldPosition = ray.GetPoint(position);
            stateMachine.freeGnarl.transform.position = (stateMachine.freeBuild.transform.up
                * ((Vector3)mouseWorldPosition - stateMachine.freeBuild.transform.position).magnitude) + stateMachine.freeBuild.transform.position;

            if (stateMachine.InputHandler.mouseLeftClick)
            {
                Attach();
            }
        }

        
    }

    private void Attach()
    {
        AttachBuild(stateMachine.currentSlot.transform.parent);
        stateMachine.slotsEnabler = stateMachine.currentSlot.GnarlHost.GetComponent<FreeSlotsEnabler>();
        stateMachine.slotsEnabler.AttachToGnarl(stateMachine.currentSlot.Degree);

        CoinsManager.singleton.TakeCoins(stateMachine.freeBuildCost);

        stateMachine.SetState(stateMachine.defaultState);
        stateMachine.freeBuild = null;
        stateMachine.freeGnarl = null;
    }
    private void AttachBuild(Transform t)
    {
        stateMachine.freeBuild.transform.SetParent(t);
    }

    

    private void Cancel()
    {
        if (stateMachine.freeBuild != null)
        {
            GameObject.Destroy(stateMachine.freeBuild);
        }
        if (stateMachine.freeGnarl != null)
        {
            GameObject.Destroy(stateMachine.freeGnarl);
        }
        stateMachine.SetState(stateMachine.defaultState);
    }
}