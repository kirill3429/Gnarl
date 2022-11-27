
using UnityEngine;
using Zenject;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [Inject] Player player;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector3 toPlayer = player.transform.position - transform.position;
        rb.AddForce(toPlayer.normalized * moveSpeed);
    }
}
