using UnityEngine;

public class Interactable : MonoBehaviour {

    public string GetInteractionText()
    {
        return "Press \'" + InputManager.InteractionKey + "\' to interact.";
    }
}
