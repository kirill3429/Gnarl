using UnityEngine;
using Zenject;

public class GnarlState : EditorState
{
    public GnarlState(EditorStateMachine stateMachine, DiContainer diContainer) : base(stateMachine, diContainer) { }
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
        stateMachine.freeBuild = diContainer.InstantiatePrefab(buildToSpawn);
        stateMachine.SetState(stateMachine.buildState);
    }

    private void FollowMouse(Ray ray)
    {
        Plane ground = new Plane(-Vector3.forward, Vector3.zero);

        if (ground.Raycast(ray, out float position))
        {
            Vector2 mouseWorldPosition = ray.GetPoint(position);
            stateMachine.freeGnarl.transform.position = stateMachine.freeBuild.transform.up
                * Mathf.Clamp(((Vector3)mouseWorldPosition - stateMachine.freeBuild.transform.position).magnitude,0, 15) + stateMachine.freeBuild.transform.position;

            

            if (stateMachine.InputHandler.mouseLeftClick && CanAttach(stateMachine.freeGnarl))
            {
                Attach();
            }
        }

        
    }

    private bool CanAttach(GameObject go)
    {
        var collider = go.GetComponent<Collider2D>();
        ContactFilter2D filter2D = new ContactFilter2D();
        filter2D.NoFilter();
        Collider2D[] collisions = new Collider2D[1];
        if (collider.OverlapCollider(filter2D, collisions) == 0)
        {
            return true;
        }
        return false;
    }

    private void Attach()
    {
        AttachBuild(stateMachine.currentSlot.transform.parent);
        stateMachine.slotsEnabler = stateMachine.currentSlot.GnarlHost.GetComponent<FreeSlotsEnabler>();
        stateMachine.slotsEnabler.AttachToGnarl(stateMachine.currentSlot.Degree);
        stateMachine.slotsEnabler.ShowSlots();

        stateMachine.coinsManager.TakeCoins(stateMachine.freeBuildCost);

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