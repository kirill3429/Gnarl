using System.Collections.Generic;
using UnityEngine;

public class MainGnarl : Gnarl
{
    List<IBuild> builds = new List<IBuild>();

    public void AssignBuilds()
    {
        FindBuilds(ref builds);
    }

    public void ActivateBuilds()
    {
        foreach (IBuild build in builds)
        {
            build.Activate();
        }
    }
    public void DeactivateBuilds()
    {
        foreach (IBuild build in builds)
        {
            build.Deactivate();
        }
    }
}
