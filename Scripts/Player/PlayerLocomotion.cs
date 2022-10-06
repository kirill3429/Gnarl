using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kirill
{
    public class PlayerLocomotion : MonoBehaviour
    {
        public Rigidbody2D rb;
        public InputHandler inputHandler;

        [SerializeField] private float rotationSpeed;
        [SerializeField] private float movementSpeed;

        public float RotationSpeed { get => rotationSpeed; set => movementSpeed = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

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
}

