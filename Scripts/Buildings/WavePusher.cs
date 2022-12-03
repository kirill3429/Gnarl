using UnityEngine;
public class WavePusher : MonoBehaviour 
{
    [SerializeField] private float duration;
    [SerializeField] private float pushForce;
    [SerializeField] private float waveSpeed;
    [SerializeField] private Transform waveCreator;

    private float startTime;

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
        Vector2 pushDirection = collision.transform.position - transform.position;
        collision.attachedRigidbody.AddForce(pushDirection.normalized * pushForce);
    }
}