using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    public InventoryItem inventoryItem;
    
    public GameObject itemIcon;
    protected Image imageComponent;

    protected bool clicked = false;

    protected virtual void Start()
    {
        imageComponent = itemIcon.GetComponent<Image>();
        imageComponent.color = Color.clear;
    }

    public virtual void Initialize(InventoryItem item)
    {
        inventoryItem = item;
        imageComponent.sprite = item.sprite;
        imageComponent.color = Color.white;
        clicked = false;
    }

    public virtual void Clear()
    {
        inventoryItem = null;
        imageComponent.sprite = null;
        imageComponent.color = Color.clear;
        clicked = false;
    }

    protected virtual void Invisible()
    {
        imageComponent.sprite = null;
        imageComponent.color = Color.clear;
        clicked = true;
    }

    public virtual void OnClick()
    {
        InventoryItem item = ClickedItem.Instance.GetSelectedItem();

        if (inventoryItem != null)
        {
            if (item == null)
            {
                ClickWithoutItemOnItem();
                
            } else if (!clicked){

                ClickWithItemOnItem(item);
                
            } else {
                ClickWithItemOnEmpty(item);
            }
        }
        else if (item != null)
        {   
            
            ClickWithItemOnEmpty(item);
        }
    }

    protected virtual void ClickWithoutItemOnItem()
    {
        ClickedItem.Instance.SelectItem(this);
        Invisible();
    }

    protected virtual void ClickWithItemOnItem(InventoryItem item)
    {
        ClickedItem.Instance.Swap(inventoryItem);

        Initialize(item);
    }

    protected virtual void ClickWithItemOnEmpty(InventoryItem item)
    {
        Initialize(item);
        ClickedItem.Instance.Placed(this);
    }
}