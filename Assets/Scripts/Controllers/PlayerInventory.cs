using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public static PlayerInventory instance;

    [SerializeField] KeyCode inventoryKey;
    [SerializeField] RectTransform invetoryPanel;
    [SerializeField] RecordController recordController;

    public List<Item> items = new List<Item>();

    private bool isOpen = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	void Start () {
	}
	
	void Update () {
        HandleInventoryPanelInput();
	}

    void HandleInventoryPanelInput()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            if (isOpen)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    void OpenInventory()
    {
        InputManager.ActivateCursorMode();
        isOpen = true;
        invetoryPanel.gameObject.SetActive(true);
    }

    void CloseInventory()
    {
        InputManager.DeactivateCursorMode();
        isOpen = false;
        invetoryPanel.gameObject.SetActive(false);
    }

    public void ListenRecord(AudioClip clip)
    {
        recordController.PlayRecording(clip);
    }


    
}
