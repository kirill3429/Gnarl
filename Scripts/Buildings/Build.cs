using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Build : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float time;
    public bool isActive { get; set; } = false;
    public float Cooldown { get => cooldown; }
    public float LastPerformedTime { get => time; }

    public abstract void Activate();
    public abstract void Deactivate();
    public virtual void Perform()
    {
        time = Time.time;
    }
}
