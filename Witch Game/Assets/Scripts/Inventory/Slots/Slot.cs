using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    public InventoryItem inventoryItem;
    

    public GameObject itemIcon;
    protected Image imageComponent;

    protected virtual void Start()
    {
        imageComponent = itemIcon.GetComponent<Image>();
        imageComponent.color = Color.clear;
    }

    public virtual void Initialize(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        imageComponent.sprite = inventoryItem.sprite;
        imageComponent.color = Color.white;
    }

    public virtual void Reset()
    {
        inventoryItem = null;
        imageComponent.sprite = null;
        imageComponent.color = Color.clear;
    }

    public virtual void OnClick()
    {
        InventoryItem item = ClickedItem.Instance.GetSelectedItem();

        if (inventoryItem != null)
        {
            if (item == null)
            {
                ClickWithoutItem();
                
            } else {

                ClickWithItemOnItem(item);
                
            }
        }
        else if (item != null)
        {   
            
            ClickWithItemOnEmpty(item);
        }
    }

    protected virtual void ClickWithoutItem()
    {
        ClickedItem.Instance.SelectItem(this);
        Reset();
    }

    protected virtual void ClickWithItemOnItem(InventoryItem item)
    {
        ClickedItem.Instance.Placed();
        ClickedItem.Instance.SelectItem(this);
        Initialize(item);
    }

    protected virtual void ClickWithItemOnEmpty(InventoryItem item)
    {
        Initialize(item);
        ClickedItem.Instance.Placed();
    }
}