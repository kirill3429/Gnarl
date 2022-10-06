using System.Collections.Generic;
using UnityEngine;

public class MainGnarl : Gnarl
{
    List<IBuild> allBuildsList = new List<IBuild>();

    public void AssignBuilds()
    {
        FindBuilds(ref allBuildsList);
    }

    public void ActivateBuilds()
    {
        foreach (IBuild build in allBuildsList)
        {
            build.Activate();
        }
    }
    public void DeactivateBuilds()
    {
        foreach (IBuild build in allBuildsList)
        {
            build.Deactivate();
        }
    }
}
