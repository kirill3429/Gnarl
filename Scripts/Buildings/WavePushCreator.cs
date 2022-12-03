using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePushCreator : Build
{
    [SerializeField] private WavePusher wavePusher;
    public override void Activate()
    {
        isActive = true;
    }

    public override void Deactivate()
    {
        isActive = false;
    }

    public override void Perform()
    {
        base.Perform();
        wavePusher.gameObject.SetActive(true);
    }
}
