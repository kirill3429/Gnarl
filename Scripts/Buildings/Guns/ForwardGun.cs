using System;
using System.Collections;
using UnityEngine;

public class ForwardGun : Build
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSocket;

    private void Awake()
    {
        Activate();
    }

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
        Instantiate(bullet, bulletSocket.position, bulletSocket.rotation);
    }
}
