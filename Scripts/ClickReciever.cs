using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ClickReciever : MonoBehaviour, IPointerClickHandler
{
    [Inject] private EditorSideBlock sideBlock;
    private BuildProperties buildProperties;
    private void Start()
    {
        buildProperties = GetComponent<BuildProperties>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        sideBlock.ShowProperties(buildProperties);
    }
}
