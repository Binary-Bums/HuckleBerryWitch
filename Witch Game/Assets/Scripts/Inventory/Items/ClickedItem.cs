using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickedItem : MonoBehaviour
{
    public static ClickedItem Instance { get; private set; }

    public GameObject dragSprite;
    private InventoryItem selectedItem;
    private GameObject draggingItem;
    public bool IsDragging => selectedItem != null;
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

    public void Reset()
    {
        lastClickedSlot.Initialize(selectedItem);
        DestroyDraggedItem();
        selectedItem = null;
    }

    public void Placed(Slot slot)
    {
        selectedItem = null;
        // if (lastClickedSlot != slot) lastClickedSlot.Moved();
            
        DestroyDraggedItem();
    }

    private void CreateDraggedItem()
    {
        draggingItem = Instantiate(dragSprite, lastClickedSlot.transform.parent);
        draggingItem.GetComponent<Image>().sprite = selectedItem.sprite;
        dragging = StartCoroutine(Dragging());
    }

    private void DestroyDraggedItem()
    {

        if (dragging != null) StopCoroutine(dragging);

        if (draggingItem != null) Destroy(draggingItem);
            
    }

    private IEnumerator Dragging()
    {
        RectTransform item = draggingItem.GetComponent<RectTransform>();
        RectTransform parent = item.transform.parent.GetComponent<RectTransform>();
        Camera uiCamera = null; // If you have a separate camera rendering the UI, assign it here.

        while (true)
        {
            Vector2 mousePos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, Input.mousePosition, uiCamera, out mousePos))
            {
                item.anchoredPosition = mousePos;
            }

            yield return null;
        }
    }
}
