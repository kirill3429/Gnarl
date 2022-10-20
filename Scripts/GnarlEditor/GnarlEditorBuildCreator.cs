
using UnityEngine;
using Kirill;
using System;

public class GnarlEditorBuildCreator : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    private GameObject freeBuild;
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnDisable()
    {
        Destroy(freeBuild);
    }


    public void CreateBuilding(GameObject buildToSpawn)
    {
        if (freeBuild == null)
        {
            freeBuild = Instantiate(buildToSpawn);
        }
        else
        {
            Destroy(freeBuild);
        }
    }

    private void Update()
    {
        if (freeBuild != null)
        {
            FollowMouse();
        }
    }

    private void FollowMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(inputHandler.mouseInput);
        Plane ground = new Plane(-Vector3.forward, Vector3.zero);
        if (inputHandler.mouseRightClick)
        {
            Destroy(freeBuild);
            return;
        }
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            if (hit.collider.CompareTag("freeSlot"))
            {
                var slotComponent = hit.collider.GetComponent<FreeSlot>();
                freeBuild.transform.position = hit.transform.position;
                freeBuild.transform.up = hit.transform.position - slotComponent.GnarlHost.position;
                if (inputHandler.mouseRightClick)
                {
                    Destroy(freeBuild);
                    return;
                }
                else if (inputHandler.mouseLeftClick)
                {   
                    AttachBuild(hit.transform.parent);
                }

                return;
            }
        }
        
        else if (ground.Raycast(ray, out float position))
        {
            Vector2 worldPosition = ray.GetPoint(position);
            freeBuild.transform.position = worldPosition;
        }

    }

    private void AttachBuild(Transform t)
    {
        freeBuild.transform.SetParent(t);
        freeBuild = null;
        TakeCoins(freeBuild.GetComponent<ShopItemInfo>());
    }

    private void TakeCoins(ShopItemInfo info)
    {
        //take money
    }
}
