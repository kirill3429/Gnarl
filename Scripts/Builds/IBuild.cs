using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuild
{
    int Weight { get; }
    void Activate();
    void Deactivate();
}
