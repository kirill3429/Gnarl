using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowStarter : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("starter");
        GetComponent<Grow>().StartGrow();
    }
}
