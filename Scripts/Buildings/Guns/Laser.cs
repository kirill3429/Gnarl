using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float rayDistance;
    [SerializeField] private float laserDamage;
    [SerializeField] private float laserDuration;
    [SerializeField] protected ParticleSystem effect;
    [SerializeField] private LayerMask enemyLayer;

    private float startTime;

    private LineRenderer lineRenderer;
    private Transform myTransform;
    private GameObject currentTarget;
    private GameObject lastTarget;
    private Health targetHealth;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        myTransform = transform;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        startTime = Time.time;
        effect.Play();
    }

    protected virtual void Update()
    {
        if (Time.time - startTime < laserDuration)
        {
            TickRay();
        }
        else
        {
           StopLaser();
        }
    }

    protected void StopLaser()
    {
        gameObject.SetActive(false);
        effect.Stop();
    }

    private void TickRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(myTransform.position, myTransform.up, rayDistance, enemyLayer);

        if (hit == false)
        {
            UpdateBeam(myTransform.up * rayDistance + myTransform.position);
        }
        else
        {
            currentTarget = hit.collider.gameObject;
            if (currentTarget != lastTarget)
            {
                targetHealth = currentTarget.GetComponent<Health>();
                if (targetHealth != null)
                targetHealth.TakeDamage(laserDamage);
            }
            else
            {
                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(laserDamage);
                }
                
                
            }
            UpdateBeam(hit.point);
        }
        
    }

    private void UpdateBeam(Vector2 end)
    {
        lineRenderer.SetPosition(0, myTransform.position);
        lineRenderer.SetPosition(1, end);
    }
}