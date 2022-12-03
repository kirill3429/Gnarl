using UnityEngine;
public class WaveDamage : MonoBehaviour 
{
    [SerializeField] private float duration;
    [SerializeField] private float damage;
    [SerializeField] private float waveSpeed;
    [SerializeField] private Transform waveCreator;
    [SerializeField] private Effect effectPrefab;

    private EffectsPool effectPool;


    private float startTime;

    public void InitializeWaveDamage()
    {
        effectPool = new EffectsPool(gameObject.name, effectPrefab);
    }

    private void OnEnable()
    {
        transform.position = waveCreator.position;
        transform.localScale = Vector2.one;
        startTime = Time.time;
    }

    private void Update()
    {
        float delta = Time.deltaTime;

        transform.localScale += Vector3.one * waveSpeed * delta;

        if (Time.time - startTime > duration)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
            var effect = effectPool.Get();
            effect.gameObject.transform.position = collision.transform.position;

        }
    }
}