using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDamageCreator : Build
{
    [SerializeField] private WaveDamage waveDamage;
    public override void Activate()
    {
        isActive = true;
    }

    public override void Deactivate()
    {
        isActive = false;
    }

    public override void Initialize()
    {
        waveDamage.InitializeWaveDamage();
    }

    public override void Perform()
    {
        base.Perform();
        waveDamage.gameObject.SetActive(true);
    }
}
