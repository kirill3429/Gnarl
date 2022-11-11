using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLocomotion : MonoBehaviour
{
    public Rigidbody2D rb;
    public InputHandler inputHandler;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;

    public float RotationSpeed { get => rotationSpeed; set { if (value >= 0) rotationSpeed = value; }  }
    public float MovementSpeed { get => movementSpeed; set { if (value >= 0) movementSpeed = value; } }

    private Transform myTransform;

    void Start()
    {
        myTransform = transform;
    }


    void Update()
    {
        inputHandler.TickInput();
    }

    private void FixedUpdate()
    {
        RotateHandler();
        MoveHandler();
    }

    private void RotateHandler()
    {
        rb.AddTorque(-inputHandler.horizontal * rotationSpeed);
    }
    private void MoveHandler()
    {
        rb.AddForce(myTransform.up * inputHandler.vertical * movementSpeed);
    }

}

