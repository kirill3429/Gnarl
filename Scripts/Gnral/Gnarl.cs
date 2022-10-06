using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gnarl : MonoBehaviour
{
    private int maxWeight = 3;

    private List<IBuild> selfBuilds = new List<IBuild>();
    public List<IBuild> AttachedBuilds { get => selfBuilds; }


    protected void FindBuilds(ref List<IBuild> builds)
    {

        foreach (Transform element in transform)
        {
            if (element.gameObject.TryGetComponent<IBuild>(out IBuild buildTemp))
            {
                builds.Add(buildTemp);
                selfBuilds.Add(buildTemp);
            }
            if (element.gameObject.TryGetComponent<Gnarl>(out Gnarl tempGnarl))
                tempGnarl.FindBuilds(ref builds);
        }
    }

    public void AddBuild(IBuild build)
    {
        int summWeight = 0;
        selfBuilds.Select(m => summWeight + m.Weight);
        if (build.Weight + summWeight > maxWeight)
        {
            return;
            // throw exception?
        }
        else
        {
            selfBuilds.Add(build);
        }

    }
    public void RemoveBuild(IBuild build)
    {

        selfBuilds.Remove(build);
    }
}
