public interface IInventoryPresenter
{
    ItemData ItemInHand { get; }
    bool RemoveItem(ItemData item);
    void PrepareItem(ItemData item);
    IReadOnlyInventory Inventory { get; }
}
