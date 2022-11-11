using System.Collections.Generic;
using UnityEngine;


public class FreeSlotsInitializer : MonoBehaviour
{
    [SerializeField] private Slot freeSlotPrefab;
    [SerializeField] private int slots;

    [HideInInspector] public List<Slot> allSlots = new List<Slot>();
    private int spawnDistance = 10;

    public void Start()
    {
        InitSlots();
        foreach (var i in allSlots)
        {
            i.gameObject.SetActive(false);
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
    private Vector3 CreateSpawnPoint(int degree, int placementDistance)
    {
        Vector2 positionToSpawn = new Vector2();
        positionToSpawn.x = transform.position.x + placementDistance * Mathf.Cos(degree * Mathf.Deg2Rad);
        positionToSpawn.y = transform.position.y + placementDistance * Mathf.Sin(degree * Mathf.Deg2Rad);
        return positionToSpawn;
    }
}
