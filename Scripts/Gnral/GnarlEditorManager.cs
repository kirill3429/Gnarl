
using UnityEngine;
using Kirill;
using System;

public class GnarlEditorManager : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    private GameObject freeBuild;
    private Transform freeBuildTransform;
    private Camera mainCamera;

    private Vector2[] rayDirections;
    private Ray2D[] rays;

    private void Start()
    {
        mainCamera = Camera.main;
        InitRayDirections(ref rayDirections);
    }

    private void InitRayDirections(ref Vector2[] rayDirections)
    {
        rayDirections = new Vector2[8];
        for (int i = 0; i < rayDirections.Length; i++)
        {
            rayDirections[i] = new Vector2();
            rayDirections[i].x = Mathf.Cos(360 * i/rayDirections.Length * Mathf.Deg2Rad);
            rayDirections[i].y = Mathf.Sin(360 * i / rayDirections.Length * Mathf.Deg2Rad);
        }
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
            //RotateToClosestEarth();


        }
    }

    private void FollowMouse()
    {
        Plane ground = new Plane(-Vector3.forward, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(inputHandler.mouseInput);

        if (ground.Raycast(ray, out float position))
        {
            Vector2 worldPosition = ray.GetPoint(position);
            freeBuild.transform.position = worldPosition;
        }
    }

    //private void RotateToClosestEarth()
    //{
    //    for (int i = 0; i < rayDirections.Length; i++)
    //    {
    //        if (Physics2D.Raycast()
    //        {

    //        }
    //    }
    //}
}
