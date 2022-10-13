using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGnarl : Gnarl
{
    List<Build> allBuildsList = new List<Build>();

    public void AssignBuilds()
    {
        FindBuilds(ref allBuildsList);
    }

    public void ActivateAllBuilds()
    {
        foreach (Build build in allBuildsList)
        {
            build.Activate();
        }
    }
    public void DeactivateAllBuilds()
    {
        foreach (Build build in allBuildsList)
        {
            build.Deactivate();
        }
    }

    private IEnumerator PerformAllBuilds()
    {
        float currentTime = Time.time;
        foreach (Build b in allBuildsList)
        {
            if (b.isActive)
            {
                if (b.LastPerformedTime - currentTime > b.Cooldown)
                {
                    b.Perform();
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
    }
}
