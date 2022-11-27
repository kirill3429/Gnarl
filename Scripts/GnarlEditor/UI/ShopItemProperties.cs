
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
    [Inject] private EditorStateMachine gnarlEditorBuildCreator;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(CreateObject);
    }

    public void CreateObject()
    {
        gnarlEditorBuildCreator.CreateBuild(ItemPrefab, CostInt);
    }
}
