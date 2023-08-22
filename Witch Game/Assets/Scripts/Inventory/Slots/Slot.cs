using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    public InventoryItem inventoryItem;
    

    public GameObject itemIcon;
    public GameObject deleteIcon;
    private Image imageComponent;
    private int slotIndex;

    protected void Start()
    {
        if (deleteIcon != null) deleteIcon.SetActive(false);
        imageComponent = itemIcon.GetComponent<Image>();
        imageComponent.color = Color.clear;
        slotIndex = transform.GetSiblingIndex();
    }

    public void Initialize(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        imageComponent.sprite = inventoryItem.sprite;
        imageComponent.color = Color.white;
        if (deleteIcon != null) deleteIcon.SetActive(true);
    }

    public void Reset()
    {
        inventoryItem = null;
        imageComponent.sprite = null;
        imageComponent.color = Color.clear;
        if (deleteIcon != null) deleteIcon.SetActive(false);
    }

    private void Delete()
    {
        Reset();
    }

    public virtual void Moved()
    {
        Delete();
    }

    public virtual void OnClick()
    {
        InventoryItem item = ClickedItem.Instance.GetSelectedItem();

        if (inventoryItem != null)
        {
            if (ClickedItem.Instance.GetSelectedItem() == null)
            {
                ClickedItem.Instance.SelectItem(this);
                Reset();
                
            } else {

                ClickedItem.Instance.Placed(this);
                ClickedItem.Instance.SelectItem(this);
                Initialize(item);
                
            }
        }
        else if (ClickedItem.Instance.GetSelectedItem() != null && inventoryItem == null)
        {   
            ClickedItem.Instance.Placed(this);
            Initialize(item);
        }
    }
}