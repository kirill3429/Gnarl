using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kirill
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;

        public Vector2 movementInput;

        public Vector2 mouseInput;

        public float cameraScroller;
        public bool mouseLeftClick = false;


        private PlayerControls inputActions;


        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputKeyboad => movementInput = inputKeyboad.ReadValue<Vector2>();

                inputActions.PlayerMouse.Mouse.performed += inputMouse => mouseInput = inputMouse.ReadValue<Vector2>();
                inputActions.PlayerMouse.Scroll.performed += inputMouseScroll => cameraScroller = inputMouseScroll.ReadValue<float>();
                inputActions.PlayerMouse.MouseClick.performed += inputMouseClick => mouseLeftClick = true;
                inputActions.PlayerMouse.MouseClick.canceled += inputMouseCancel => mouseLeftClick = false;
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput()
        {
            MoveInput();
        }

        private void MoveInput()
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
        }
    }
 
}

