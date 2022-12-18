using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ShopItemPointerHandler : MonoBehaviour, IPointerEnterHandler
{
    [Inject] private EditorSideBlock editorSideBlock;
    private BuildProperties buildProperties;
    private void Start()
    {
        var prefab = GetComponent<ShopItemProperties>().ItemPrefab;
        buildProperties = prefab.GetComponent<BuildProperties>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowProperties();
    }

    public void ShowProperties()
    {
        editorSideBlock.ShowProperties(buildProperties);

    }

}
