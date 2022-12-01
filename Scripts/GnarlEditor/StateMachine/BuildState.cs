using UnityEngine;
public class BuildState : EditorState
{
    public BuildState(EditorStateMachine stateMachine) : base(stateMachine) { }
    public override void Tick(Ray ray)
    {
        if (stateMachine.InputHandler.mouseRightClick) 
        {
            GameObject.Destroy(stateMachine.freeBuild);
            stateMachine.SetState(stateMachine.defaultState);
            return;
        }

        FollowMouse(stateMachine.freeBuild, ray);
        TryAttachToFreeSlot(ray);
    }
    public override void CreateBuild(GameObject buildToSpawn, int cost)
    {
        if (CoinsManager.singleton.Coins < cost)
            return;

        GameObject.Destroy(stateMachine.freeBuild);
        stateMachine.freeBuild = GameObject.Instantiate(buildToSpawn);
        stateMachine.freeBuildCost = cost;
    }

    private void FollowMouse(GameObject freeBuild, Ray ray)
    {
        Plane ground = new Plane(-Vector3.forward, Vector3.zero);

        if (ground.Raycast(ray, out float position))
        {
            Vector2 worldPosition = ray.GetPoint(position);
            freeBuild.transform.position = worldPosition;
        }
    }
    private void TryAttachToFreeSlot(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, stateMachine.freeSlotsLayerMask))
        {
            
            if (stateMachine.freeBuild != null)
            {
                stateMachine.currentSlot = hit.collider.GetComponent<Slot>();
                stateMachine.freeBuild.transform.position = hit.transform.position;
                stateMachine.freeBuild.transform.up = hit.transform.position - stateMachine.currentSlot.GnarlHost.position;

                if (stateMachine.InputHandler.mouseLeftClick)
                {
                    if (stateMachine.freeBuild.CompareTag("GnarlConnector"))
                    {
                        stateMachine.SetState(stateMachine.gnarlState);
                        stateMachine.freeGnarl = GameObject.Instantiate(stateMachine.freeBuild.GetComponent<GnarlConnector>().gnarlPrefab, stateMachine.freeBuild.transform);
                        stateMachine.freeBuild.GetComponent<GnarlConnector>().childGnarl = stateMachine.freeGnarl;
                    }
                    else
                    {
                        AttachBuild(stateMachine.currentSlot.transform.parent);
                        stateMachine.slotsEnabler = stateMachine.currentSlot.GnarlHost.GetComponent<FreeSlotsEnabler>();
                        stateMachine.slotsEnabler.AttachToGnarl(stateMachine.currentSlot.Degree);

                        CoinsManager.singleton.TakeCoins(stateMachine.freeBuildCost);

                        stateMachine.SetState(stateMachine.defaultState);
                        stateMachine.freeBuild.GetComponent<Build>().Initialize();
                        stateMachine.freeBuild = null;
                    }
                    
                }
            }
        }
        

    }
    private void AttachBuild(Transform t)
    {
        stateMachine.freeBuild.transform.SetParent(t);
    }



}