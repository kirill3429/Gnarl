using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnarlEditor : MonoBehaviour
{
    [SerializeField] private FreeSlot freeSlotPrefab;
    [SerializeField] private int slots;

    private List<int> TakenPlaces = new List<int>();
    private List<FreeSlot> freeSlots = new List<FreeSlot>();
    private int spawnDistance = 10;

    private void Start()
    {
        EnableEditorMode();
    }

    public void EnableEditorMode()
    {
        RenderSlots();
    }
    public void DisableEditorMode()
    {
        ClearFreeSlotsView();
    }


    private void RenderSlots()
    {
        int slotDegree = 360 / slots;
        int spawnDegree = 0;

        for (int i = 0; i < slots; i++)
        {
            if (!TakenPlaces.Contains(spawnDegree))
            {
                Vector3 positionToSpawn = CreateSpawnPoint(spawnDegree, spawnDistance);
                FreeSlot freeSlot = Instantiate(freeSlotPrefab, positionToSpawn, Quaternion.identity, transform);
                freeSlot.Degree = spawnDegree;
                freeSlot.GnarlHost = transform;
                freeSlots.Add(freeSlot);
            }
            spawnDegree += slotDegree;
        }
    }

    public void AttachToGnarl(int degree)
    {
        TakenPlaces.Add(degree);
        UpdateSlotsView();
        
    }
    public void RemoveFromGnarl(int degree)
    {
        TakenPlaces.Remove(degree);
        UpdateSlotsView();

    }

    private void UpdateSlotsView()
    {
        ClearFreeSlotsView();
        RenderSlots();

    }

    private void ClearFreeSlotsView()
    {
        foreach (FreeSlot slot in freeSlots)
        {
            Destroy(slot.gameObject);
        }
    }

    private Vector3 CreateSpawnPoint(int degree, int placementDistance)
    {
        Vector2 positionToSpawn = new Vector2();

        positionToSpawn.x = placementDistance * Mathf.Cos(degree * Mathf.Deg2Rad);
        positionToSpawn.y = placementDistance * Mathf.Sin(degree * Mathf.Deg2Rad);

        return positionToSpawn;
    }
}
