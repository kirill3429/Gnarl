using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    public void DefineTargetPosition()
    {
        BuildsController[] gnarls = GetComponentsInChildren<BuildsController>();
        Vector3 newCameraPosition = Vector3.zero;
        foreach (BuildsController gnarl in gnarls)
        {
            newCameraPosition += gnarl.transform.position;
        }

        newCameraPosition = newCameraPosition /gnarls.Length;

        cameraTarget.position = newCameraPosition;
    }
}
