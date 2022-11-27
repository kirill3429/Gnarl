
using UnityEngine;
using Zenject;

public class ShopItemsInitializer : MonoBehaviour
{
    public BuildProperties[] builds;
    [SerializeField] private Transform shopContent;
    [SerializeField] private GameObject itemPrefab;

    [Inject] private DiContainer diContainer;

    private void Start()
    {
        FillShopContent();
    }

    private void FillShopContent()
    {
        foreach (var build in builds)
        {
            ShopItemProperties itemProperties = diContainer.InstantiatePrefabForComponent<ShopItemProperties>(itemPrefab, shopContent);
            itemProperties.ItemName.text = build.Name;
            itemProperties.ItemDescription.text = build.Description;
            itemProperties.ItemAdvancedDescription.text = build.AdvancedDescription;
            itemProperties.Cost.text = build.Cost.ToString();
            itemProperties.CostInt = build.Cost;
            itemProperties.ItemPrefab = build.gameObject;
            //itemInfo.IconImage.sprite = build.Icon;

            
        }
    }
}
