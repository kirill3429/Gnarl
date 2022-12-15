using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditorSideBlock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buildName;
    [SerializeField] private TextMeshProUGUI buildDescription;
    [SerializeField] private TextMeshProUGUI advancedDisription;
    public void ShowProperties(BuildProperties buildProperties)
    {
        buildName.text = buildProperties.Name;
        buildDescription.text = buildProperties.Description;
        advancedDisription.text = buildProperties.AdvancedDescription;
    }
}
