using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] Image foregroundImage;
 
    
    private string Text;
    private event Action onClick;

    void OnEnable()
    {
        SetForegroundFillAmount(1);
    }

    public void OnClickItem()
    {
        PlayerInventory.instance.SetLastClickedItem(this);
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

    public void SetForegroundFillAmount(float ratio)
    {
        foregroundImage.fillAmount = ratio;
    }
}
