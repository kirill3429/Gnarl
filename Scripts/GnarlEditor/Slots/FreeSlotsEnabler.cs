using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(FreeSlotsInitializer))]
public class FreeSlotsEnabler : MonoBehaviour
{
    private InputHandler inputHandler;
    private List<int> takenPlaces = new List<int>();
    private List<Slot> allSlots;

    private void Start()
    {
        allSlots = GetComponent<FreeSlotsInitializer>().allSlots;
        inputHandler = FindObjectOfType<InputHandler>();
        inputHandler.editorModeButton += ToogleEditorMode;
        HideSlots();
    }

    private void OnDestroy()
    {
        inputHandler.editorModeButton -= ToogleEditorMode;
    }

    private void ToogleEditorMode()
    {
        if (!EditorEnabler.isActive)
        {
            HideSlots();
        }
        else
        {
            ShowSlots();
        }
    }


    public void ShowSlots()
    {
        foreach (Slot slot in allSlots)
        {
            if (!takenPlaces.Contains(slot.Degree))
            {
                slot.gameObject.SetActive(true);
            }
        }
    }

    private void HideSlots()
    {
        foreach (Slot slot in allSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }
    public void AttachToGnarl(int degree)
    {
        takenPlaces.Add(degree);
        var slot = allSlots.First(m => m.Degree == degree);
        slot.gameObject.SetActive(false);
        
    }
    public void RemoveFromGnarl(int degree)
    {
        takenPlaces.Remove(degree);
        var slot = allSlots.First(m => m.Degree == degree);
        slot.gameObject.SetActive(true);
    }


}
