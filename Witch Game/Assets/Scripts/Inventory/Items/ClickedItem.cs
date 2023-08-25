using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickedItem : MonoBehaviour
{
    public static ClickedItem Instance { get; private set; }

    public GameObject dragSprite;
    private InventoryItem selectedItem;
    private GameObject draggingItem;
    private Slot lastClickedSlot;
    private Coroutine dragging;

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

    public InventoryItem GetSelectedItem()
    {
        return selectedItem;
    }

    public void SelectItem(Slot slot)
    {
        lastClickedSlot = slot;
        selectedItem = slot.inventoryItem;
        CreateDraggedItem();
    }

    public void Placed(Slot slot)
    {
        selectedItem = null;
        if (slot != lastClickedSlot) lastClickedSlot.Clear();
            
        DestroyDraggedItem();
    }

    public void Swap(InventoryItem item)
    {
        selectedItem = item;
            
        DestroyDraggedItem();

        
        CreateDraggedItem();
    }

    public void Reset()
    {
        if (dragging != null)
        {
            lastClickedSlot.Initialize(selectedItem);
            DestroyDraggedItem();
        }
        
        selectedItem = null;
        lastClickedSlot = null;
    }

    private void CreateDraggedItem()
    {
        draggingItem = Instantiate(dragSprite, transform);
        draggingItem.GetComponent<Image>().sprite = selectedItem.sprite;
        dragging = StartCoroutine(Dragging());
    }

    private void DestroyDraggedItem()
    {

        if (dragging != null) {StopCoroutine(dragging); dragging = null; };

        if (draggingItem != null) Destroy(draggingItem);
            
    }

    private IEnumerator Dragging()
    {
        RectTransform item = draggingItem.GetComponent<RectTransform>();
        RectTransform parent = item.transform.parent.GetComponent<RectTransform>();

        while (true)
        {
            Vector2 mousePos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, Input.mousePosition, null, out mousePos))
            {
                item.anchoredPosition = mousePos;
            }

            yield return null;
        }
    }
}
