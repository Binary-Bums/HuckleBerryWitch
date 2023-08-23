using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject Inventory;
    public KeyCode inventoryKey = KeyCode.E;

    private bool isInventoryOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(inventoryKey))
        {
            isInventoryOpen = !isInventoryOpen;
            if (!isInventoryOpen) ClickedItem.Instance.Reset();
            Inventory.SetActive(isInventoryOpen);
            
        }
    }
}
