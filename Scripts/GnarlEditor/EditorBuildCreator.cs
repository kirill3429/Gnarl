
using UnityEngine;


public class EditorBuildCreator : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private LayerMask freeSlotsLayerMask;
    private GameObject freeBuild;
    private Camera mainCamera;
    private int freeBuildCost;

    private void Start()
    {
        mainCamera = Camera.main;
    }


    public void CreateBuild(GameObject buildToSpawn, int cost)
    {
        if (CoinsManager.singleton.Coins < cost)
            return;

        if (freeBuild == null)
        {
            freeBuild = Instantiate(buildToSpawn);
            freeBuildCost = cost;
        }
        else
        {
            Destroy(freeBuild);
            freeBuild = Instantiate(buildToSpawn);
            freeBuildCost = cost;

        }
    }

    private void Update()
    {
        if (inputHandler.mouseRightClick)
        {
            Destroy(freeBuild);
            return;
        }


        Ray ray = CreateRay();

        if (freeBuild != null)
        {
            FollowMouse(ray);
        }

        if (Physics.Raycast(ray, out RaycastHit hit, freeSlotsLayerMask))
        {
            TryAttachToFreeSlot(ray, hit);
        }
        


    }

    private Ray CreateRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(inputHandler.mouseInput);
        return ray;

    }

    private void FollowMouse(Ray ray)
    {
        Plane ground = new Plane(-Vector3.forward, Vector3.zero);

        if (ground.Raycast(ray, out float position))
        {
            Vector2 worldPosition = ray.GetPoint(position);
            freeBuild.transform.position = worldPosition;
        }
    }

    private void TryAttachToFreeSlot(Ray ray, RaycastHit hit)
    {
        if (freeBuild != null)
        {
            Slot slotComponent = hit.collider.GetComponent<Slot>();
            freeBuild.transform.position = hit.transform.position;
            freeBuild.transform.up = hit.transform.position - slotComponent.GnarlHost.position;

            if (inputHandler.mouseLeftClick)
            {
                AttachBuild(hit.transform.parent);
                slotComponent.GnarlHost.GetComponent<FreeSlotsEnabler>()
                    .AttachToGnarl(slotComponent.Degree);
            }
        }
        
    }


    private void AttachBuild(Transform t)
    {
        freeBuild.transform.SetParent(t);
        freeBuild = null;
        TakeCoins(freeBuildCost);
    }

    private void TakeCoins(int cost)
    {
        CoinsManager.singleton.TakeCoins(cost);
    }

    private void OnDisable()
    {
        Destroy(freeBuild);
    }
}
