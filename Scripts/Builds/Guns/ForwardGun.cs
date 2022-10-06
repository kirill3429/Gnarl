using System;
using System.Collections;
using UnityEngine;

public class ForwardGun : MonoBehaviour, IBuild
{
    [SerializeField] private int weight;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSocket;

    private bool isActive;
    public int Weight { get => weight;}

    private void Awake()
        
    {
        Activate();
    }

    private IEnumerator Shooot()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(0.3f);
            PerformShot();
        }
        
    }

    public void Activate()
    {
        isActive = true;
        StartCoroutine(Shooot());
    }

    public void Deactivate()
    {
        isActive = false;
        StopAllCoroutines();
    }

    private void PerformShot()
    {
        if (isActive)
        {
            Instantiate(bullet, bulletSocket.position, bulletSocket.rotation);
        }

    }
}
