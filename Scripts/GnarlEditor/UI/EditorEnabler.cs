using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class EditorEnabler : MonoBehaviour
{
    [Inject] private InputHandler inputHandler;
    [SerializeField] private GameObject editor;
    public static bool isActive = false;

    private void Start()
    {
        inputHandler.editorModeButton += () =>
        {
            isActive = !isActive;
            ToogleEditor();
            Time.timeScale = isActive ? 0 : 1;
        };
    }

    private void ToogleEditor()
    {
        editor.SetActive(isActive);
    }
}
