using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kirill;

public class GnarlEditorFreeSlotsRenderer : MonoBehaviour
{
    [SerializeField] private Slot freeSlotPrefab;
    [SerializeField] private int slots;

    private InputHandler inputHandler;
    private List<int> takenPlaces = new List<int>();
    private List<Slot> allSlots = new List<Slot>();
    private int spawnDistance = 10;

    private void Start()
    {
        InitSlots();
        ClearFreeSlotsView();
        inputHandler = GetComponentInParent<InputHandler>();
        inputHandler.editorModeButton += ToogleEditorMode;
    }

    private void OnDestroy()
    {
        inputHandler.editorModeButton -= ToogleEditorMode;
    }

    private void ToogleEditorMode()
    {
        if (GnalEditorEnabler.isActive)
        {
            RenderSlots();
        }
        else
        {
            ClearFreeSlotsView();
        }
    }


    private void InitSlots()
    {
        int slotDegree = 360 / slots;
        int spawnDegree = 0;

        for (int i = 0; i < slots; i++)
        {

            Vector3 positionToSpawn = CreateSpawnPoint(spawnDegree, spawnDistance);
            Slot freeSlot = Instantiate(freeSlotPrefab, positionToSpawn, Quaternion.identity, transform);
            freeSlot.Degree = spawnDegree;
            freeSlot.GnarlHost = transform;
            allSlots.Add(freeSlot);
            spawnDegree += slotDegree;
        }
    }

    private void RenderSlots()
    {
        foreach (Slot slot in allSlots)
        {
            if (!takenPlaces.Contains(slot.Degree))
            {
                slot.gameObject.SetActive(true);
            }
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

    private void ClearFreeSlotsView()
    {
        foreach (Slot slot in allSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    private Vector3 CreateSpawnPoint(int degree, int placementDistance)
    {
        Vector2 positionToSpawn = new Vector2();

        positionToSpawn.x = transform.position.x + placementDistance * Mathf.Cos(degree * Mathf.Deg2Rad);
        positionToSpawn.y = transform.position.y + placementDistance * Mathf.Sin(degree * Mathf.Deg2Rad);

        return positionToSpawn;
    }
}
