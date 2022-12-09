using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float rotateSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(rotateSpeed);
    }
}
