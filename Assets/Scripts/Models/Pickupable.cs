using Assets.Scripts.Models;
using UnityEngine;

public class Pickupable : MonoBehaviour {

    public Item item;

    public void PickupItem()
    {
        PlayerInventory.instance.AddItem(item);
        Destroy(gameObject);
    }

    public string GetInteractionText()
    {
        return "Press \'" + InputManager.InteractionKey + "\' to pickup.";
    }
}
