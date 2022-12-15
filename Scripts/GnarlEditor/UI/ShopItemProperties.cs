
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class ShopItemProperties : MonoBehaviour
{
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemAdvancedDescription;
    public TextMeshProUGUI Cost;
    public int CostInt;
    public Image IconImage;
    public GameObject ItemPrefab;
    public BuildProperties buildProperties;
    [Inject] private EditorStateMachine gnarlEditorBuildCreator;
    [Inject] private EditorSideBlock editorSideBlock;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(CreateObject);
        buildProperties = ItemPrefab.GetComponent<BuildProperties>();
        

    }

    public void CreateObject()
    {
        gnarlEditorBuildCreator.CreateBuild(ItemPrefab, CostInt);
    }

    public void ShowProperties()
    {
        editorSideBlock.ShowProperties(buildProperties);
    }
}
