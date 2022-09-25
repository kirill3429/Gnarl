using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kirill
{
    public class PlayerLocomotion : MonoBehaviour
    {
        public Rigidbody2D rb;
        public InputHandler inputHandler;

        public float rotationSpeed;
        public float movementSpeed;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            float delta = Time.deltaTime;
            inputHandler.TickInput(delta);
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
            rb.AddForce(transform.up * inputHandler.vertical * movementSpeed);
        }

    }
}

