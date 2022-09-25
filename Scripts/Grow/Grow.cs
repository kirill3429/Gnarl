using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private float placementDegree;
    [SerializeField] private float placementDistance;
    [SerializeField] private float growSpeed = 2f;

    public float PlacementDegree { get => placementDegree; set => placementDegree = value; }
    public float PlacementDistance { get => placementDistance; set => placementDistance = value; }
    public float GrowSpeed { get => growSpeed; set => growSpeed = value; }

    private List<Grow> childs = new List<Grow>();


    private void Awake()
    {
        AssignChilds();
        StartGrow();
    }
    private void AssignChilds()
    {
        Grow childTemp;
        foreach (Transform el in transform)
        {
            if (TryGetComponent<Grow>(out childTemp))
                childs.Add(childTemp);
        }
    }

    public void StartGrow()
    {
        StartCoroutine(MoveToPosition());
        StartCoroutine(GrowChilds());
    }

    private IEnumerator GrowChilds()
    {
        yield return new WaitForSeconds(1f);
        foreach (Grow child in childs)
        {
            child.StartGrow();
        }
    }

    private IEnumerator MoveToPosition()
    {
        Vector2 spawnPoint = CreateSpawnPoint();

        if (transform.parent != null)
        {
            while ((Vector2)transform.localPosition != spawnPoint)
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, spawnPoint, GrowSpeed * Time.deltaTime);
                yield return null;
            }
        }

    }

    private Vector2 CreateSpawnPoint()
    {
        Vector2 spawnPoint = new Vector2();

        spawnPoint.x = PlacementDistance * Mathf.Cos(PlacementDegree * Mathf.Deg2Rad);
        spawnPoint.y = PlacementDistance * Mathf.Sin(PlacementDegree * Mathf.Deg2Rad);

        return spawnPoint;
    }


}
