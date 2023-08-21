using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    public InventoryItem inventoryItem;

    public GameObject itemIcon;
    public GameObject deleteIcon;
    private Image imageComponent;
    private PlayerInventory playerInventory;
    private bool isDragging;

    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        if (deleteIcon != null) deleteIcon.SetActive(false);
        imageComponent = itemIcon.GetComponent<Image>();
        imageComponent.color = Color.clear;
    }

    private void Update() {
        if (isDragging)
        {
            Vector2 mousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(itemIcon.transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out mousePos);
            itemIcon.GetComponent<RectTransform>().anchoredPosition = mousePos;
        }
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

    public void Delete()
    {
        int i = transform.GetSiblingIndex();
        playerInventory.RemoveFromInventory(i);
    }

    public void OnClick()
    {
        Debug.Log("clicekd ");

        if (inventoryItem != null)
        {
            Debug.Log("on item");
            ClickedItem.Instance.SelectItem(this);
            isDragging = true;
        }
        else if (ClickedItem.Instance.selectedItem != null)
        {


            playerInventory.AddToInventory(ClickedItem.Instance.selectedItem);
            ClickedItem.Instance.Placed();
            isDragging = false;
        }
    }
}