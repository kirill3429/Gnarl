using System.Collections.Generic;
using UnityEngine;

public class Gnarl : MonoBehaviour
{
    protected void FindBuilds(ref List<IBuild> builds)
    {
        IBuild buildTemp;
        Gnarl tempGnarl;
        foreach (Transform element in transform)
        {
            if (element.gameObject.TryGetComponent<IBuild>(out buildTemp))
                builds.Add(buildTemp);
            if (element.gameObject.TryGetComponent<Gnarl>(out tempGnarl))
                tempGnarl.FindBuilds(ref builds);
        }
    }
}
