using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Transform player;
    Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerLocomotion>().transform;
    }
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 toPlayer = player.position - transform.position;

        rb.AddForce(toPlayer.normalized * moveSpeed);
    }
}
