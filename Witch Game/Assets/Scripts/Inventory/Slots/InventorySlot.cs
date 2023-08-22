using UnityEngine;

public class InventorySlot : Slot
{
    public GameObject deleteIcon;

    protected override void Start()
    {
        base.Start();
        deleteIcon.SetActive(false);
    }

    public override void Initialize(InventoryItem inventoryItem)
    {
        base.Initialize(inventoryItem);
        deleteIcon.SetActive(true);
    }

    public override void Clear()
    {
        base.Clear();
        deleteIcon.SetActive(false);
    }

    protected override void Invisible()
    {
        base.Invisible();
        deleteIcon.SetActive(false);
    }
}