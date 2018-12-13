using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour {

    [SerializeField] Text textComponent;

    
    private string Text;
    private event Action onClick;

    public void OnClickItem()
    {
        onClick();
    }

    public void SetOnClickEventHandler(Action action)
    {
        onClick = action;
    }

    public void SetText(string text)
    {
        textComponent.text = text;
    }
}
