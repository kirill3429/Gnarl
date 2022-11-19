using System.Collections.Generic;
using UnityEngine;

public class BuildsController : MonoBehaviour
{
    
    private List<Build> selfBuilds = new List<Build>();
    public List<Build> AttachedBuilds { get => selfBuilds; }


    protected void FindBuilds(ref List<Build> builds)
    {

        foreach (Transform element in transform)
        {
            if (element.gameObject.TryGetComponent<Build>(out Build build))
            {
                builds.Add(build);
                selfBuilds.Add(build);
            }
            if (element.gameObject.TryGetComponent<GnarlConnector>(out GnarlConnector connector))
            {
                connector.childGnarl.GetComponent<BuildsController>().FindBuilds(ref builds);

            }
        }
    }

    public void AddBuild(Build build)
    {
        selfBuilds.Add(build);
    }
    public void RemoveBuild(Build build)
    {
        selfBuilds.Remove(build);
    }
}
