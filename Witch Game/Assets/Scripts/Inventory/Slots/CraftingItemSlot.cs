public class CraftingItemSlot : Slot {
    protected override void ClickWithItemOnEmpty(InventoryItem item)
    {
        if (item is Item) base.ClickWithItemOnEmpty(item);
    }

    protected override void ClickWithItemOnItem(InventoryItem item)
    {
        if (item is Item) base.ClickWithItemOnItem(item);
    }
}