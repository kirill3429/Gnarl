using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemInfo : MonoBehaviour
{
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemAdvancedDescription;
    public TextMeshProUGUI Cost;
    public Image IconImage;
    public GameObject ItemPrefab;
    public GnarlEditorBuildCreator gnarlEditorBuildCreator;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(CreateObject);
    }

    public void CreateObject()
    {
        gnarlEditorBuildCreator.CreateBuilding(ItemPrefab);
    }
}
