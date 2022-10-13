
using UnityEngine;
using Kirill;
using System;

public class GnarlEditorManager : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    private GameObject freeBuild;
    private Transform freeBuildTransform;
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }



    public void CreateBuilding(GameObject buildToSpawn)
    {
        if (freeBuild == null)
        {
            freeBuild = Instantiate(buildToSpawn);
            freeBuildTransform = freeBuild.transform;
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

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("freeSlot"))
            {
                var slotComponent = hit.collider.GetComponent<FreeSlot>();
                freeBuild.transform.position = hit.transform.position;
                freeBuild.transform.up = hit.transform.position - slotComponent.GnarlHost.position;

                if (inputHandler.mouseLeftClick)
                {
                    Debug.Log(slotComponent.Degree);
                    
                    freeBuild.transform.SetParent(hit.transform.parent);
                    freeBuild = null;
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
}
