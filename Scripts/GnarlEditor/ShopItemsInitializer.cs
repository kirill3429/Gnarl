
using UnityEngine;

public class ShopItemsInitializer : MonoBehaviour
{
    public BuildScriptable[] builds;
    [SerializeField] private Transform shopContent;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private EditorBuildCreator gnarlEditorCreator;

    private void Start()
    {
        FillShopContent();
    }

    private void FillShopContent()
    {
        foreach (var build in builds)
        {
            GameObject shopItem = Instantiate(itemPrefab, shopContent);
            ShopItemProperties itemProperties = shopItem.GetComponent<ShopItemProperties>();

            itemProperties.gnarlEditorBuildCreator = gnarlEditorCreator;

            itemProperties.ItemName.text = build.Name;
            itemProperties.ItemDescription.text = build.Description;
            itemProperties.ItemAdvancedDescription.text = build.AdvancedDescription;
            itemProperties.Cost.text = build.Cost.ToString();
            itemProperties.CostInt = build.Cost;
            itemProperties.ItemPrefab = build.BuildPrefab;
            //itemInfo.IconImage.sprite = build.Icon;

            
        }
    }
}
