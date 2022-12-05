using UnityEngine;

public class LaserAdvanced : Laser
{
    [SerializeField] private float rotationSpeed;
    public float current;

    protected override void Update()
    {
        base.Update();
        current += Time.deltaTime * 10 * rotationSpeed;

        var f = Mathf.PingPong(current, 140);

        transform.localEulerAngles = new Vector3(0, 0, f - 70);
        effect.transform.localEulerAngles = transform.localEulerAngles;
        if (current > 20100)
        {
            current = 0;
        }
        
    }
}
