using UnityEngine;

public class ClickedItem : MonoBehaviour
{
    public static ClickedItem Instance { get; private set; }

    public InventoryItem selectedItem;
    public bool IsDragging => selectedItem != null;
    public InventorySlot lastClickedSlot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectItem(InventorySlot slot)
    {
        lastClickedSlot = slot;
        selectedItem = slot.inventoryItem;
    }

    public void Reset()
    {
        lastClickedSlot.Initialize(selectedItem);
        selectedItem = null;
    }

    public void Placed()
    {
        selectedItem = null;
    }
}
