using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public Vector2 movementInput;

    public Vector2 mouseInput;

    public float cameraScroller;
    public bool mouseLeftClick = false;
    public bool mouseRightClick = false;


    public delegate void OnEditorToogleButtonDown();
    public event OnEditorToogleButtonDown editorModeButton;


    private PlayerControls inputActions;


    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputKeyboad => movementInput = inputKeyboad.ReadValue<Vector2>();

            inputActions.PlayerMouse.Mouse.performed += inputMouse => mouseInput = inputMouse.ReadValue<Vector2>();
            inputActions.PlayerMouse.Scroll.performed += inputMouseScroll => cameraScroller = inputMouseScroll.ReadValue<float>();

            inputActions.PlayerButtons.EditorModeButton.performed += inputEditorButton => editorModeButton?.Invoke();
        }

        inputActions.Enable();
    }

    private void TickMouseClick()
    {
        mouseLeftClick = inputActions.PlayerMouse.MouseClick.WasPerformedThisFrame();
        mouseRightClick = inputActions.PlayerMouse.RightMouseClick.WasPerformedThisFrame();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput()
    {
        MoveInput();
        TickMouseClick();
    }

    private void MoveInput()
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
    }
}
 

