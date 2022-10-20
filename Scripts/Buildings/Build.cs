using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Build : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private int tier;
    protected float time;
    public bool isActive { get; set; }
    public float Cooldown { get => cooldown; }
    public float LastPerformedTime { get => time; }
    public int Tier 
    {
        get => tier;
        set {
                if (value <= 4 && value > 0)
                    tier = value;
            } 
    }
    public abstract void Activate();
    public abstract void Deactivate();
    public abstract void Perform();
}
