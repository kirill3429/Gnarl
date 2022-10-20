using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BuildData", menuName = "ScriptableObjects/BuildData", order = 1)]
public class BuildScriptable : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public string AdvancedDescription;
    public int Cost;
    public GameObject BuildPrefab;
}
