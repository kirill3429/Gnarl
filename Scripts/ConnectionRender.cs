using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionRender : MonoBehaviour
{
    LineRenderer line;
    private void Awake()
    {
        ConnectionLineInit();
    }
    private void Update()
    {
        RenderConnectionLine();
    }


    private void RenderConnectionLine()
    {

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.parent.position);
        
    }
    private void ConnectionLineInit()
    {
        line = GetComponent<LineRenderer>();
        line.startColor = Color.green;
        line.endColor = Color.grey;
        line.positionCount = 2;
    }
}
