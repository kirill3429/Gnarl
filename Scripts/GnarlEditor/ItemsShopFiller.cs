using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsShopFiller : MonoBehaviour
{
    public BuildScriptable[] builds;
    [SerializeField] private Transform shopContent;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GnarlEditorBuildCreator gnarlEditorCreator;

    private void Start()
    {
        FillShopContent();
    }

    private void FillShopContent()
    {
        foreach (var build in builds)
        {
            GameObject shopItem = Instantiate(itemPrefab, shopContent);
            ShopItemInfo itemInfo = shopItem.GetComponent<ShopItemInfo>();

            itemInfo.gnarlEditorBuildCreator = gnarlEditorCreator;

            itemInfo.ItemName.text = build.Name;
            itemInfo.ItemDescription.text = build.Description;
            itemInfo.ItemAdvancedDescription.text = build.AdvancedDescription;
            itemInfo.Cost.text = build.Cost.ToString();
            //itemInfo.IconImage.sprite = build.Icon;
            itemInfo.ItemPrefab = build.BuildPrefab;

            
        }
    }
}
