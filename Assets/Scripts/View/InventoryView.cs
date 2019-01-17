using Assets.Scripts.Models;
using UnityEngine;

public class InventoryView : MonoBehaviour {
    
    void OnEnable()
    {
        RenderItems();
    }

    void OnDisable()
    {
        Clear();
    }

    void RenderItems()
    {
        int i = 0;
        foreach (Item item in PlayerInventory.instance.items)
        {
            var itemView = transform.GetChild(i).GetComponent<InventoryItemView>();
            itemView.gameObject.SetActive(true);

            itemView.SetText(item.name);
            if (item.GetType().Equals(typeof(RecordItem)))
            {
                itemView.SetOnClickEventHandler(() =>
                {
                    PlayerInventory.instance.ListenRecord((item as RecordItem).clip);
                });
            }
            i++;
        }
    }

    void Clear()
    {
        foreach (Transform t in transform)
        {
            var itemView = t.GetComponent<InventoryItemView>();
            itemView.SetText("");
            itemView.SetOnClickEventHandler(() => { });
            itemView.gameObject.SetActive(false);
        }
    }
}
