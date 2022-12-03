using UnityEngine;

public class LaserAdvanced : Laser
{
    [SerializeField] private float rotationSpeed;
    private float current;

    protected override void Update()
    {
        base.Update();
        current += Time.deltaTime * 10 * rotationSpeed;

        var f = Mathf.PingPong(current, 140);

        transform.localEulerAngles = new Vector3(0, 0, f - 70);
        effect.transform.localEulerAngles = transform.localEulerAngles;
        if (Mathf.Abs(transform.localEulerAngles.z) == 70) StopLaser();
        
    }
}
